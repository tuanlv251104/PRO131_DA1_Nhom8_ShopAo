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
    public class HoaDonCTConfig : IEntityTypeConfiguration<HoaDonCT>
    {
        public void Configure(EntityTypeBuilder<HoaDonCT> builder)
        {
            builder.HasKey(p=> p.Id);
            builder.HasOne(p => p.HoaDon).WithMany(p => p.HoaDonCT).HasForeignKey(p => p.IdHoaDon);
            builder.HasOne(p => p.SanPham).WithMany(p => p.HoaDonCTs).HasForeignKey(p => p.IdsanPham);
        }
    }
}
