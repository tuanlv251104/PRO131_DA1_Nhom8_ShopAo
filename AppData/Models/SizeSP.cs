using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class SizeSP
    {
        public Guid Id { get; set; }
        public string TenSize { get; set; }
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
