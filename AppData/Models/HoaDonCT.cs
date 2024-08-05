using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class HoaDonCT
    {
        public Guid Id { get; set; }
        public Guid IdsanPham { get; set; }
        public Guid IdHoaDon { get; set; }
        public int SoLuong { get; set; }
        public decimal TongTien { get; set; }
        public int Status { get; set; }
        public virtual HoaDon HoaDon { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
