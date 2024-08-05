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
    public class SanPhamConfig : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.DanhSachSP).WithMany(p => p.SanPham).HasForeignKey(p => p.IdDanhMucSP);
			builder.HasOne(p => p.SizeSP).WithMany(p => p.SanPham).HasForeignKey(p => p.SizeId);
			builder.HasOne(p => p.MauSacSP).WithMany(p => p.SanPham).HasForeignKey(p => p.MauSacId);
		}
    }
}
