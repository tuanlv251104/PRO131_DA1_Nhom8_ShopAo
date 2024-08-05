using AppData.IServices;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Services
{
	public class DanhMucServices : IDanhMucServices
	{
		AppDbContext _db;
        public DanhMucServices()
        {
            _db = new AppDbContext();
        }

		public List<DanhSachSP> GetAllDanhMuc()
		{
			return _db.danhSachSPs.ToList();
		}

		public DanhSachSP GetById(Guid id)
		{
			return _db.danhSachSPs.FirstOrDefault(p => p.Id == id);
		}
	}
}
