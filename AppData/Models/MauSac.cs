using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class MauSac
    {
        public Guid Id {  get; set; }
        public string TenMau { get; set; }
        public virtual List<SanPhamCT> SanPhamCT { get; set; }
    }
}
