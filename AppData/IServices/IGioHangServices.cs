using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IServices
{
    public interface IGioHangServices
    {
        public List<GioHangCT> GetAddGioHang();
        public GioHangCT GetById(Guid id);
        public bool AddGioHangCT(GioHangCT ct);
        public bool UpdateGioHang(GioHangCT ct);
        public bool DeleteGioHangCT(Guid id);
    }
}
