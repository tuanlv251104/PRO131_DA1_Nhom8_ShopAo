using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class SanPhamCT
    {
        public Guid Id { get; set; }
        public Guid SanPhamId { get; set; }
        public Guid SizeId { get; set; }
        public Guid MauSacId { get; set; }
        public int SoLuong { get; set; }
        public string ThuongHieu { get; set; }
        public string MoTa { get; set; }
        public string TrangThaiSP { get; set; }
        public virtual List<HoaDonCT> HoaDonCTs { get; set; }
        public virtual List<GioHangCT> GioHangCTs { get;set; }
        public virtual SizeSP SizeSP { get; set; }
        public virtual MauSac MauSacSP { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
