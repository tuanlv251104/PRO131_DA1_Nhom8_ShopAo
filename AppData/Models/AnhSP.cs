using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class AnhSP
    {
        public Guid Id {  get; set; }
        public Guid SanPhamCTId { get; set; }
        public string TenSP { get; set; }
        public string ImgSP { get; set; }
        public virtual SanPhamCT SanPhamCT { get; set;}
    }
}
