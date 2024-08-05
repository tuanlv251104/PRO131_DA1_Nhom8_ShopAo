using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Configurations
{
    public class GioHangCTConfig : IEntityTypeConfiguration<GioHangCT>
    {
        public void Configure(EntityTypeBuilder<GioHangCT> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.GioHang).WithMany(p=> p.GioHangCTs).HasForeignKey(p=>p.Username);
            builder.HasOne(p => p.SanPham).WithMany(p => p.GioHangCTs).HasForeignKey(p => p.SanPhamId);
        }
    }
}
