using AppData.IServices;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Services
{
	public class SizeServices : ISizeServices
	{
		AppDbContext _db;
        public SizeServices()
        {
            _db = new AppDbContext();
        }
        public List<SizeSP> GetAllSize()
		{
			return _db.sizeSPs.ToList();
		}

		public SizeSP GetById(Guid id)
		{
			return _db.sizeSPs.FirstOrDefault(p => p.Id == id);
		}
	}
}
