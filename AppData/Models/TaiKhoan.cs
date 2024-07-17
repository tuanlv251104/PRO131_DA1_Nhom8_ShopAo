using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Models;

namespace AppData.Models
{
    public class TaiKhoan
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual GioHang GioHang { get; set; }
        public virtual List<HoaDon> HoaDons { get; set; }
    }
}
