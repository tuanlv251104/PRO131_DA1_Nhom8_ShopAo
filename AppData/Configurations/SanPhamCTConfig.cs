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
    public class SanPhamCTConfig : IEntityTypeConfiguration<SanPhamCT>
    {
        public void Configure(EntityTypeBuilder<SanPhamCT> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.SanPham).WithMany(p => p.SanPhamCT).HasForeignKey(p => p.SanPhamId);
            builder.HasOne(p => p.SizeSP).WithMany(p => p.SanPhamCT).HasForeignKey(p => p.SizeId);
            builder.HasOne(p => p.MauSacSP).WithMany(p => p.SanPhamCT).HasForeignKey(p => p.MauSacId);
            builder.HasMany(p => p.AnhSP).WithOne(p => p.SanPhamCT).HasForeignKey(p=> p.SanPhamCTId);
        }
    }
}
