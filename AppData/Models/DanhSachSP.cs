using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class DanhSachSP
    {
        public Guid Id { get; set; }
        public string TenDanhMuc { get; set; }
        public virtual ICollection<SanPham> SanPham { get; set;}
    }
}
