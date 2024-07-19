using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Models;

namespace AppData.Models
{
    public class TaiKhoan
    {
        [Required]
        [StringLength(450, MinimumLength = 10, ErrorMessage = "Độ dài phải từ 10 đến 450 kí tự")]
        public string Username { get; set; }
        [Required]
        [StringLength(450, MinimumLength = 10, ErrorMessage = "Độ dài phải từ 10 đến 450 kí tự")]
        public string Password { get; set; }
        [EmailAddress(ErrorMessage = "Email chưa đúng định dạng")]
        public string Email { get; set; }
        public virtual GioHang GioHang { get; set; }
        public virtual List<HoaDon> HoaDons { get; set; }
    }
}
