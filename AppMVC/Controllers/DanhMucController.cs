using AppData.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers
{
	public class DanhMucController : Controller
	{
		AppDbContext _db;
        public DanhMucController()
        {
            _db = new AppDbContext();
        }
        public IActionResult Index(string TimDM="")
		{
			if (!string.IsNullOrWhiteSpace(TimDM))
			{
				// Sử dụng Where để tìm kiếm tài khoản theo tên người dùng
				var danhmuc = _db.danhSachSPs
								  .Where(x => x.TenDanhMuc.ToUpper().Contains(TimDM.ToUpper()))
								  .ToList();
				return View(danhmuc);
			}
			var data = _db.danhSachSPs.ToList();
			return View(data);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(DanhSachSP danhSachSP)
		{
			_db.danhSachSPs.Add(danhSachSP);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Update(Guid id)
		{
			var UpdateItem = _db.danhSachSPs.Find(id);
			return View(UpdateItem);
		}
		[HttpPost]
		public IActionResult Edit(Guid id, DanhSachSP danhSachSP)
		{
			var UpdateItem = _db.danhSachSPs.Find(danhSachSP.Id);
			UpdateItem.TenDanhMuc = danhSachSP.TenDanhMuc;
			_db.danhSachSPs.Update(UpdateItem);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
