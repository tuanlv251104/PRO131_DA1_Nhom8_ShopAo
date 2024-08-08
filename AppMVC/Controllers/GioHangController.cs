using AppData.IServices;
using AppData.Models;
using AppData.Services;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppMVC.Controllers
{
    public class GioHangController : Controller
    {
        AppDbContext _db;
        private readonly IGioHangServices _ghct;
        public GioHangController()
        {
            _db = new AppDbContext();
            _ghct = new GioHangServices();
        }
        public IActionResult Index()
        {
            var check = HttpContext.Session.GetString("username");
            var gioHangCt = _db.gioHangCTs.Include(p => p.SanPham).Include(p => p.GioHang).Where(p=>p.Username == check).ToList();
            decimal totalAmount = 0;
            foreach (var cartDetail in gioHangCt)
            {
                totalAmount += cartDetail.SanPham.GiaSP * cartDetail.SoLuong;
            }
            
            if (string.IsNullOrEmpty(check))
            {
                return RedirectToAction("Login", "TaiKhoan");
            }
            else
            {
                var GioHangView = new GioHangCTViewModel { gioHangCTs = gioHangCt, TotalAmount = totalAmount };
                return View(GioHangView);
            }
        }
        [HttpPost]
        public IActionResult AddtoCart(Guid id, int soluong)
        {
            var check = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(check))
            {
                return RedirectToAction("Login", "TaiKhoan");
            }
            else
            {
                var GiohangCt = _db.gioHangCTs.Include(p=> p.SanPham).Include(p=> p.GioHang).FirstOrDefault(p=> p.SanPhamId== id && p.Username == check);
                if(GiohangCt == null)
                {
                    GioHangCT gioHangCT = new GioHangCT()
                    {
                        Id = Guid.NewGuid(),
                        SanPhamId = id,
                        SoLuong = soluong,
                        Status = 1,
                        Username = check
                    };
                    if (_ghct.AddGioHangCT(gioHangCT)) ;
                        
                }
                else
                {
                    GiohangCt.SoLuong = GiohangCt.SoLuong + soluong;
                    _db.gioHangCTs.Update(GiohangCt);
                    _db.SaveChanges();
                        
                }
                return RedirectToAction("SanPhamDetail", "Home", new {id = id});
            }
        }

        public IActionResult UpdateSoLuong(GioHangCT gioHangCT ,int quantity)
        {
            gioHangCT.SoLuong  = gioHangCT.SoLuong + quantity;
            _ghct.UpdateGioHang(gioHangCT);
            return RedirectToAction("Index", "GioHang");
        }
        public IActionResult Delete(Guid id , GioHangCT gioHangCT)
        {
            var cart = _db.gioHangCTs.Find(gioHangCT.Id);
            _db.gioHangCTs.Remove(cart);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult CheckOut()
        {
            var gioHangCt = _db.gioHangCTs.Include(p => p.SanPham).Include(p => p.GioHang).ToList();
            decimal totalAmount = 0;
            foreach (var cartDetail in gioHangCt)
            {
                totalAmount += cartDetail.SanPham.GiaSP * cartDetail.SoLuong;
            }
            var GioHangView = new GioHangCTViewModel { gioHangCTs = gioHangCt, TotalAmount = totalAmount };
            return View(GioHangView);
        }

        public ActionResult ItemThanhToan()
        {
            var gioHangCt = _db.gioHangCTs.Include(p => p.SanPham).Include(p => p.GioHang).ToList();
            decimal totalAmount = 0;
            foreach (var cartDetail in gioHangCt)
            {
                totalAmount += cartDetail.SanPham.GiaSP * cartDetail.SoLuong;
            }
            var GioHangView = new GioHangCTViewModel { gioHangCTs = gioHangCt, TotalAmount = totalAmount };
            var check = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(check))
            {
                return RedirectToAction("Login", "TaiKhoan");
            }
            else
            {
                return View(GioHangView);
            }
        }
    }
}
