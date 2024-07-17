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
    public class DanhMucSPConfig : IEntityTypeConfiguration<DanhSachSP>
    {
        public void Configure(EntityTypeBuilder<DanhSachSP> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
