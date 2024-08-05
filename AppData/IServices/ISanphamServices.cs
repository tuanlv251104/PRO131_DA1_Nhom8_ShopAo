using AppData.Models;
using AppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
	public interface ISanphamServices
	{
		public List<SanPham> GetAll();
		public SanPham GetById(Guid id);
		public List<SanPham> GetSamPhamTen(string name);
		public bool AddSP(SanPham sanPham);
		public bool SuaSP(SanPhamViewModel sanPhamViewModel, Guid id);
		public bool XoaSP(Guid id);
	}
}
