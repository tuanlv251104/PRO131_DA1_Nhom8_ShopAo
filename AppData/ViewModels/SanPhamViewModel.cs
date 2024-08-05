using AppData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
	public class SanPhamViewModel
	{
		//Sản phẩm
		public SanPham SanPham { get; set; }
		public List<SanPham> sanPhams { get; set; }
		public Guid sanPhamId { get; set; }
		public string TenSP { get; set; }
		public string AnhSP { get; set; }
		public decimal GiaSP { get; set; }
		public string MoTa { get; set; }
		public int SoLuong { get; set; }
		public string ThuongHieu { get; set; }
		public string TrangThaiSP { get; set; }
		//Danh mục 
		public DanhSachSP DanhSachSP { get; set; }
		public Guid DanhMucId { get; set; }
		public string DanhMucTen { get; set; }
		public List<SelectListItem> DanhMucs { get; set; }
		// Màu sắc
		public MauSac MauSacSP { get; set; }
		public Guid MauSacId { get; set; }
		public string MauSacTen { get; set; }
		public List<SelectListItem> MauSacs { get; set; }
		// Size
		public SizeSP SizeSP { get; set; }
		public Guid IdSize { get; set; }
		public string tenSize { get; set; }
		public List<SelectListItem> Sizes { get; set; }
	}
}
