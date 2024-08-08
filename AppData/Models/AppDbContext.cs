using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TaiKhoan> taiKhoans { get; set; }
        public DbSet<HoaDon> hoaDons { get; set; }
        public DbSet<HoaDonCT> hoaDonCTs { get; set; }
        public DbSet<SanPham> sanPhams { get; set; }
        public DbSet<GioHang> gioHangs { get; set; }
        public DbSet<GioHangCT> gioHangCTs { get; set; }
        public DbSet<DanhSachSP> danhSachSPs { get; set; }
        public DbSet<SizeSP> sizeSPs { get; set; }
        public DbSet<MauSac> mauSacs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-LEVANTUA;Initial Catalog=ShopAo;Integrated Security=True; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
