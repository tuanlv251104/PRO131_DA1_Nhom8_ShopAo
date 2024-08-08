using AppData.IServices;
using AppData.Models;
using AppData.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Services
{
	public class SanPhamServices : ISanphamServices
	{
		AppDbContext _db;
		public SanPhamServices()
		{
			_db = new AppDbContext();
		}
		public bool AddSP(SanPham sanPham)
		{
			try
			{
				sanPham.Id = Guid.NewGuid();
				_db.sanPhams.Add(sanPham);
				_db.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public List<SanPham> GetAll()
		{
			return _db.sanPhams.Include(p => p.DanhSachSP).ToList();
		}

		public SanPham GetById(Guid id)
		{
			return _db.sanPhams.Include(p => p.DanhSachSP).Include(p=>p.MauSacSP).Include(p=>p.SizeSP).FirstOrDefault(p => p.Id == id);
		}

		public List<SanPham> GetSamPhamTen(string name)
		{
			return _db.sanPhams.Where(p => p.TenSP.Contains(name)).ToList();
		}

		public bool SuaSP(SanPhamViewModel sanPhamViewModel, Guid id)
		{
			try
			{
				var sp = _db.sanPhams.FirstOrDefault(p => p.Id == id);
				sp.TenSP = sanPhamViewModel.TenSP;
				sp.AnhSP = sanPhamViewModel.AnhSP;
				sp.GiaSP = sanPhamViewModel.GiaSP;
				sp.DanhSachSP = sanPhamViewModel.DanhSachSP;
				sp.SoLuong = sanPhamViewModel.SoLuong;
				sp.MoTa = sanPhamViewModel.MoTa;
				sp.MauSacSP = sanPhamViewModel.MauSacSP;
				sp.SizeSP = sanPhamViewModel.SizeSP;
				sp.ThuongHieu = sanPhamViewModel.ThuongHieu;
				sp.TrangThaiSP = sanPhamViewModel.TrangThaiSP;
				_db.sanPhams.Update(sp);
				_db.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public bool XoaSP(Guid id)
		{
			return false;
		}
	}
}
