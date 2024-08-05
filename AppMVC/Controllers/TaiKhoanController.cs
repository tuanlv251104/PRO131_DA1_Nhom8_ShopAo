using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppMVC.Controllers
{
    public class TaiKhoanController : Controller
    {
        AppDbContext _db;
        public TaiKhoanController()
        {
            _db = new AppDbContext();
        }
        public IActionResult Index(string TimTK = "")
        {
            if (!string.IsNullOrWhiteSpace(TimTK))
            {
                // Sử dụng Where để tìm kiếm tài khoản theo tên người dùng
                var taiKhoan = _db.taiKhoans
                                  .Where(x => x.Username.ToUpper().Contains(TimTK.ToUpper()))
                                  .ToList();
                return View(taiKhoan);
            }
            var data = _db.taiKhoans.ToList();
            return View(data);
        }
        public IActionResult Login(string username, string password)
        {
            if (username == null && password == null)
            {
                return View();
            }
            else
            {
                var data = _db.taiKhoans.FirstOrDefault(p => p.Username == username && p.Password == password);
                if (data == null)
                {
                    return Content("Đăng nhập thất bại mời kiểm tra lại");
                }
                else if (username == "admin12345" && password == "admin12345")
                {
                    HttpContext.Session.SetString("username", username);
                    return RedirectToAction("Index", "TaiKhoan");
                }
                else
                {
                    HttpContext.Session.SetString("username", username);
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(TaiKhoan taiKhoan)
        {
            try
            {
                _db.taiKhoans.Add(taiKhoan);
                GioHang gioHang = new GioHang()
                {
                    Username = taiKhoan.Username,
                    Status = 1
                };
                _db.gioHangs.Add(gioHang);
                _db.SaveChanges();
                TempData["Status"] = "Tạo tài khoản thành công";
                return RedirectToAction("Login");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("username"); // Xóa dữ liệu của username đã login
            return RedirectToAction("Index", "Home");
        }
    }
}
