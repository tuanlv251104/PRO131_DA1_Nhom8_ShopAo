using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class HoaDon
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public Guid IdMaGiamGia { get; set; }
        public string TenNguoiNhan { get; set; }
        public int SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayMua { get; set; }
        public string TrangThaiDonHang { get; set; }
        public string TrangThaiThanhToan { get; set; }
        public decimal tien { get; set; }
        public int Status { get; set; }
        public virtual List<HoaDonCT> HoaDonCT { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }  
        public virtual MaGiamGia MaGiamGia { get;set; }
    }
}
