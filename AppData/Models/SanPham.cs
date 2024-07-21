using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public  class SanPham
    {
        public Guid Id { get; set; }
        public Guid IdDanhMucSP { get; set; }
        public string AnhSP { get; set; }
        public string TenSP { get; set; }
		public decimal GiaSP { get; set; }
		public virtual DanhSachSP DanhSachSP { get; set; }
        public virtual List<SanPhamCT> SanPhamCT { get; set; }
    }
}
