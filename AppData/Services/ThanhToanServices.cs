using AppData.IServices;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Services
{
    public class ThanhToanServices : IThanhToanServices
    {
        AppDbContext _db;
        public ThanhToanServices()
        {
            _db = new AppDbContext();
        }
        public bool AddHoaDonCT(HoaDonCT hd)
        {
            throw new NotImplementedException();
        }

        public bool DeleteHoaDonCT(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<HoaDonCT> GetAllHoaDon()
        {
            return _db.hoaDonCTs.Include(p=>p.SanPham).Include(p=>p.HoaDon).ToList();
        }

        public HoaDonCT GetById(Guid id)
        {
            return _db.hoaDonCTs.Include(p => p.SanPham).Include(p => p.HoaDon).FirstOrDefault(p=>p.Id == id);
        }

        public bool UpdateHoaDon(HoaDonCT hd)
        {
            throw new NotImplementedException();
        }
    }
}
