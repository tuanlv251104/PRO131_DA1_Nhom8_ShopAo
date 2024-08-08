using AppData.IServices;
using AppData.Models;
using AppData.Services;
using AppData.ViewModels;
using AppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISanphamServices _spsv;
        private readonly IDanhMucServices _dmsv;
        private readonly IMauSacServices _msv;
        private readonly ISizeServices _ssv;
        AppDbContext _db;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _db = new AppDbContext();
            _spsv = new SanPhamServices();
            _dmsv = new DanhMucServices();
            _msv = new MauSacServices();
            _ssv = new SizeServices();
        }
        
        public IActionResult Index()
        {
            var datasp = new SanPhamViewModel();
            datasp.sanPhams = _db.sanPhams.Take(8).ToList();
            var data = HttpContext.Session.GetString("username"); // Lấy data từ session
            if (data == null) ViewData["login"] = "Chưa đăng nhập";
            else ViewData["login"] = "Xin chào " + data;
            return View(datasp);
        }

        public IActionResult SanPhamDetail(Guid id)
        {
            SanPham sanPham = _db.sanPhams.Include(p=> p.DanhSachSP).Include(p=> p.MauSacSP).Include(p=> p.SizeSP).FirstOrDefault(x => x.Id == id);
            var viewModel = new SanPhamViewModel()
            {
                SanPham = sanPham,
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
                Sizes = _db.sizeSPs.ToList().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSize
                }).ToList()
            };
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}