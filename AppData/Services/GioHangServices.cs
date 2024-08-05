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
    public class GioHangServices : IGioHangServices
    {
        AppDbContext _db;
        public GioHangServices()
        {
            _db = new AppDbContext();
        }
        public bool AddGioHangCT(GioHangCT ct)
        {
            try
            {
                ct.Id = Guid.NewGuid();
                _db.gioHangCTs.Add(ct);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteGioHangCT(Guid id)
        {
            try
            {
                var GioHangct = _db.gioHangCTs.FirstOrDefault(p => p.Id == id);
                _db.gioHangCTs.Remove(GioHangct);
                _db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<GioHangCT> GetAddGioHang()
        {
            return _db.gioHangCTs.Include(p=> p.SanPham).Include(p=> p.GioHang).ToList();
        }

        public GioHangCT GetById(Guid id)
        {
            return _db.gioHangCTs.Include(p => p.SanPham).Include(p => p.GioHang).FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateGioHang(GioHangCT ct)
        {
            try
            {
                var gh = _db.gioHangCTs.FirstOrDefault(p => p.Id == ct.Id);
                gh.SanPham = ct.SanPham;
                gh.SanPhamId = ct.SanPhamId;
                gh.GioHang = ct.GioHang;
                gh.SoLuong = ct.SoLuong;
                _db.gioHangCTs.Update(gh);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
