using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class GioHangCT
    {
        public Guid Id { get; set; }
        public Guid SanPhamCTId { get; set; }
        public string Username { get; set; }
        public int SoLuong { get; set; }
        public int Status { get; set; }
        public virtual GioHang GioHang { get; set; }
        public virtual SanPhamCT SanPhamCT { get; set; }
    }
}
