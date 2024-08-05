using AppData.IServices;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Services
{
	public class MauSacServices : IMauSacServices
	{
		AppDbContext _db;
        public MauSacServices()
        {
            _db = new AppDbContext();
        }
        public List<MauSac> GetAllMau()
		{
			return _db.mauSacs.ToList();
		}

		public MauSac GetById(Guid id)
		{
			return _db.mauSacs.FirstOrDefault(p => p.Id == id);
		}
	}
}
