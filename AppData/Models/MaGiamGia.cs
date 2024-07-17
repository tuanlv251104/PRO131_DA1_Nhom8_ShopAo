using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class MaGiamGia
    {
        public Guid Id { get; set; }
        public string TenMaGiamGia { get; set; }
        public string Ma { get; set; }
        public int PhanTramGiam { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int SoLuong { get; set; }
        public virtual HoaDon HoaDon { get; set; }
    }
}
