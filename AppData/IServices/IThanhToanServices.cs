using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IThanhToanServices
    {
        public List<HoaDonCT> GetAllHoaDon();
        public HoaDonCT GetById(Guid id);
        public bool AddHoaDonCT(HoaDonCT hd);
        public bool UpdateHoaDon(HoaDonCT hd);
        public bool DeleteHoaDonCT(Guid id);
    }
}
