using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModels
{
    public class GioHangCTViewModel
    {
        //Giỏ hàng 
        public List<GioHangCT> gioHangCTs { get; set; }
        public string username { get; set; }
        public decimal TotalAmount { get; set; }

        public decimal TongTiens()
        {
            var Tong = gioHangCTs.Sum(s => s.SanPham.GiaSP * s.SoLuong);
            return Tong;
        }
    }
}
