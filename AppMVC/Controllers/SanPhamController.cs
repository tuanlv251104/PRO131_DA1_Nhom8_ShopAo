using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;

namespace AppMVC.Controllers
{
	public class SanPhamController : Controller
	{
		AppDbContext _db;
        public SanPhamController()
        {
            _db = new AppDbContext();
        }
        public IActionResult Index(string TimSP = "")
		{
			if (!string.IsNullOrWhiteSpace(TimSP))
			{
				// Sử dụng Where để tìm kiếm tài khoản theo tên người dùng
				var sanpham = _db.sanPhams
								  .Where(x => x.TenSP.ToUpper().Contains(TimSP.ToUpper()))
								  .ToList();
				return View(sanpham);
			}
			var data = _db.sanPhams.ToList();
			return View(data);
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(SanPham sanPham, IFormFile imgFile)
		{
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", imgFile.FileName);
            // vd kết quả thu được sẽ có dạng wwwroot/img/concho.png;
            // Copy ảnh tải lên vào thư mục root
            var stream = new FileStream(path, FileMode.Create);
            imgFile.CopyTo(stream); // Copy cái ảnh mà được các bạn chọn vào cái stream đó
                                    // Cập nhật đường dẫn ảnh 
            sanPham.AnhSP = imgFile.FileName;
			_db.sanPhams.Add(sanPham);
			_db.SaveChanges();
			return RedirectToAction("Index");
        }

		public IActionResult Update(Guid id)
		{
			var UpdateItem = _db.sanPhams.Find(id);
			return View(UpdateItem);
		}
		[HttpPost]
		public IActionResult Update(Guid id, SanPham sanPham)
		{
			var updateItem = _db.sanPhams.Find(sanPham.Id);
			updateItem.TenSP = sanPham.TenSP;
			updateItem.AnhSP = sanPham.AnhSP;
			updateItem.GiaSP = sanPham.GiaSP;
			updateItem.IdDanhMucSP = sanPham.IdDanhMucSP;
			_db.sanPhams.Update(updateItem);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
