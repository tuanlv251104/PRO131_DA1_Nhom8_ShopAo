using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppData.IServices;
using AppData.Services;

namespace AppMVC.Controllers
{
	public class SanPhamController : Controller
	{
		AppDbContext _db;
		private readonly ISanphamServices _Isv;
		public SanPhamController()
		{
			_db = new AppDbContext();
			_Isv = new SanPhamServices();
		}
		public IActionResult Index(string TimSP = "")
		{
			var viewModel = new SanPhamViewModel();
			if (!string.IsNullOrWhiteSpace(TimSP))
			{
				// Sử dụng Where để tìm kiếm tài khoản theo tên người dùng
				var sanpham = viewModel.TenSP.ToUpper().Contains(TimSP.ToUpper());
				return View(sanpham);
			}
			viewModel.sanPhams = _db.sanPhams.Include(p => p.DanhSachSP).Include(p=> p.MauSacSP).Include(p=> p.SizeSP).ToList();
			return View(viewModel);
		}

		public IActionResult Create()
		{
			var viewModel = new SanPhamViewModel
			{
				DanhMucs = _db.danhSachSPs.ToList().Select(s => new SelectListItem
				{
					Value = s.Id.ToString(),
					Text = s.TenDanhMuc
				}).ToList(),
				MauSacs = _db.mauSacs.ToList().Select(s => new SelectListItem
				{
					Value = s.Id.ToString(),
					Text = s.TenMau
				}).ToList(),
				Sizes = _db.sizeSPs.ToList().Select(s=> new SelectListItem
				{
					Value = s.Id.ToString(),
					Text = s.TenSize
				}).ToList()
			};

			return View(viewModel);
		}
		[HttpPost]
		public IActionResult Create(SanPhamViewModel sanPhamView, IFormFile imgFile)
		{
			var sanPham = new SanPham()
			{
				TenSP = sanPhamView.TenSP,
				AnhSP = sanPhamView.AnhSP,
				GiaSP = sanPhamView.GiaSP,
				MoTa = sanPhamView.MoTa,
				SoLuong = sanPhamView.SoLuong,
				ThuongHieu = sanPhamView.ThuongHieu,
				TrangThaiSP = sanPhamView.TrangThaiSP,
				MauSacId = sanPhamView.MauSacId,
				SizeId = sanPhamView.IdSize,
				IdDanhMucSP = sanPhamView.DanhMucId
			};
			if (imgFile != null && imgFile.Length > 0)
			{
				var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", imgFile.FileName);
				// vd kết quả thu được sẽ có dạng wwwroot/img/concho.png;
				// Copy ảnh tải lên vào thư mục root
				using (var stream = new FileStream(path, FileMode.Create))
				{
					imgFile.CopyTo(stream); // Copy cái ảnh mà được các bạn chọn vào cái stream đó
											// Cập nhật đường dẫn ảnh
				}
				sanPham.AnhSP = imgFile.FileName;
			}
			var sp = _db.sanPhams.Include(p => p.DanhSachSP).Include(p => p.MauSacSP).Include(p => p.SizeSP).ToList();
			foreach (var item in sp)
			{
				if (item.TenSP == sanPhamView.TenSP && item.IdDanhMucSP == sanPhamView.DanhMucId)
				{
					var thongbao = "(Name + Brand) already exists!";
					TempData["ThongBaoCreate"] = thongbao;
					return RedirectToAction("Create", new { thongbao });
				}
			}
			if (_Isv.AddSP(sanPham))
				return RedirectToAction("Index");
			var danhMuc = _db.danhSachSPs.Find(sanPhamView.DanhMucId);
			sanPhamView.DanhMucTen = danhMuc.TenDanhMuc;
			sanPhamView.DanhMucs = _db.danhSachSPs.ToList().Select(s => new SelectListItem
			{
				Value = s.Id.ToString(),
				Text = s.TenDanhMuc
			}).ToList();
			var mau = _db.mauSacs.Find(sanPhamView.MauSacId);
			sanPhamView.MauSacTen = mau.TenMau;
			sanPhamView.MauSacs = _db.mauSacs.ToList().Select(s => new SelectListItem
			{
				Value = s.Id.ToString(),
				Text = s.TenMau
			}).ToList();
			var size = _db.sizeSPs.Find(sanPhamView.IdSize);
			sanPhamView.tenSize = size.TenSize;
			sanPhamView.Sizes = _db.sizeSPs.ToList().Select(s => new SelectListItem
			{
				Value = s.Id.ToString(),
				Text = s.TenSize
			}).ToList();
			return View(sanPhamView);
		}

		public IActionResult Update(SanPhamViewModel model,Guid id)
		{
			if(_Isv.SuaSP(model, id))
			{
				return RedirectToAction("Index");
			}
			model.DanhMucs = _db.danhSachSPs.ToList().Select(s => new SelectListItem
			{
				Value = s.Id.ToString(),
				Text = s.TenDanhMuc
			}).ToList();
			model.MauSacs = _db.mauSacs.ToList().Select(s => new SelectListItem
			{
				Value = s.Id.ToString(),
				Text = s.TenMau
			}).ToList();
				model.Sizes = _db.sizeSPs.ToList().Select(s => new SelectListItem
				{
					Value = s.Id.ToString(),
					Text = s.TenSize
				}).ToList();
			return View(model);

        }
		[HttpGet]
		public IActionResult Update(Guid id)
		{
			SanPham sp = _Isv.GetById(id);
			var updateItem = new SanPhamViewModel
			{
				SanPham = sp,
				TenSP = sp.TenSP,
				AnhSP = sp.AnhSP,
				MoTa = sp.MoTa,
				SoLuong = sp.SoLuong,
				ThuongHieu = sp.ThuongHieu,
				TrangThaiSP = sp.TrangThaiSP,
				MauSacSP = sp.MauSacSP,
				SizeSP = sp.SizeSP,
				DanhSachSP = sp.DanhSachSP,
                DanhMucs = _db.danhSachSPs.ToList().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenDanhMuc
                }).ToList(),
				DanhMucTen = sp.DanhSachSP.TenDanhMuc,
                MauSacs = _db.mauSacs.ToList().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenMau
                }).ToList(),
				MauSacTen = sp.MauSacSP.TenMau,
                Sizes = _db.sizeSPs.ToList().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSize
                }).ToList(),
				tenSize = sp.SizeSP.TenSize,
            };
			return View(updateItem);
		}

		public IActionResult Delete(Guid id, SanPham sanPham)
		{
			var delete = _db.sanPhams.Find(sanPham.Id);
			_db.sanPhams.Remove(delete);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Details(Guid id)
		{
			SanPham sanPham = _db.sanPhams.FirstOrDefault(s => s.Id == id);
			var viewModel = new SanPhamViewModel()
			{
				SanPham = sanPham,
				DanhSachSP = sanPham.DanhSachSP,
				MauSacSP = sanPham.MauSacSP,
				SizeSP = sanPham.SizeSP,
			};
			return View(viewModel);
		}

		public IActionResult Search(string tk)
		{
			if (string.IsNullOrEmpty(tk))
			{
				return RedirectToAction("Index");
			}
			var check = _Isv.GetSamPhamTen(tk);
			var view = new SanPhamViewModel()
			{
				sanPhams = check
			};
			return View("index", view);
		}
	}
}
