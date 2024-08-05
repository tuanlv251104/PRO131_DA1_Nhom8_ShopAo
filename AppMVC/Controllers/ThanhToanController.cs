using AppData.IServices;
using AppData.Models;
using AppData.Services;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppMVC.Controllers
{
    public class ThanhToanController : Controller
    {
        AppDbContext _db;
        private readonly ISanphamServices _spsv;
        private readonly IGioHangServices _ghsv;
        private readonly IThanhToanServices _ttsv;
        public ThanhToanController()
        {
            _db = new AppDbContext();
            _spsv = new SanPhamServices();
            _ghsv = new GioHangServices();
            _ttsv = new ThanhToanServices();
        }
        public IActionResult Index()
        {
            //check xem đã đăng nhập chưa
            var check = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(check))//
            {
                return RedirectToAction("Login", "TaiKhoan");
            }
            else
            {
                var Billitem = _db.hoaDons.Include(p=>p.HoaDonCT).Include(p=>p.TaiKhoan).Include(p=>p.MaGiamGia).Where(p => p.Username == check).ToList();
                return View(Billitem);
            }
        }
        //
        public IActionResult QlHoaDon()
        {
            //check xem đã đăng nhập chưa
            //var check = HttpContext.Session.GetString("username");
            //if (string.IsNullOrEmpty(check))//
            //{
            //    return RedirectToAction("Login", "TaiKhoan");
            //}
            //else
            //{
                var Billitem = _db.hoaDons.Include(p => p.HoaDonCT).Include(p => p.TaiKhoan).Include(p => p.MaGiamGia).ToList();
                return View(Billitem);
            //}
        }
        //
        public IActionResult AddHoaDon(Guid id)
        {
            var check = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(check))
            {
                return RedirectToAction("Login", "TaiKhoan");
            }
            else
            {
                var billItem = _db.gioHangCTs.Include(p => p.SanPham).Include(p => p.GioHang).FirstOrDefaultAsync(p => p.Username == check);
                if(billItem == null) return Content("Không có sản phẩm trong giỏ hàng");
                else
                {
                    decimal TongTien = 0;
                    foreach (var item in _ghsv.GetAddGioHang())
                    {
                        var sanpham = _db.sanPhams.Include(p=>p.DanhSachSP).Include(p=>p.MauSacSP).Include(p=>p.SizeSP).FirstOrDefault(p => p.Id == item.SanPhamId);
                        if(sanpham != null)
                        {
                            TongTien += sanpham.GiaSP * item.SoLuong;
                        }
                    }
                    HoaDon hoaDon = new HoaDon()
                    {
                        Id = Guid.NewGuid(),
                        Status = 1,
                        Username = check,
                        NgayMua = DateTime.Today,
                        tien = TongTien,
                        TenNguoiNhan = "long",
                        SoDienThoai = Int32.Parse("0392275922"),
                        DiaChi = "hà nội",
                        //adf1fa21-9d3a-4027-8f45-a39cc071d7c8
                        IdMaGiamGia = Guid.Parse("adf1fa21-9d3a-4027-8f45-a39cc071d7c8"),
                        TrangThaiDonHang = "Chờ sử lý",
                        TrangThaiThanhToan = "Thanh toán khi nhận hàng"
                    };
                    _db.hoaDons.Add(hoaDon);
                    _db.SaveChanges();
                    foreach (var item in _db.gioHangCTs.Include(p => p.SanPham).Include(p => p.GioHang).Where(p=> p.Username == check).ToList())
                    {
                        HoaDonCT hoaDonCT = new HoaDonCT()
                        {
                            Id = Guid.NewGuid(),
                            IdHoaDon = hoaDon.Id,
                            IdsanPham = item.SanPhamId,
                            SoLuong = item.SoLuong,
                            Status = 1,
                        };
                        var data = _db.sanPhams.Include(p => p.DanhSachSP).Include(p => p.MauSacSP).Include(p => p.SizeSP).FirstOrDefault(p => p.Id == hoaDonCT.IdsanPham);
                        data.SoLuong = data.SoLuong - hoaDonCT.SoLuong;
                        _db.hoaDonCTs.Add(hoaDonCT);
                        _db.gioHangCTs.Remove(item);
                    }
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index","ThanhToan");
        }

		public IActionResult Update(Guid id)
		{
			var UpdateItem = _db.hoaDons.Find(id);
			return View(UpdateItem);
		}
		[HttpPost]
		public IActionResult Update(Guid id, HoaDon hoaDon)
		{
			var UpdateItem = _db.hoaDons.Find(hoaDon.Id);
            UpdateItem.TrangThaiDonHang = hoaDon.TrangThaiDonHang;
            UpdateItem.TrangThaiThanhToan = hoaDon.TrangThaiThanhToan;
			_db.hoaDons.Update(UpdateItem);
			_db.SaveChanges();
			return RedirectToAction("QLHoaDon");
		}
	}
}
