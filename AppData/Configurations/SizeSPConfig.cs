﻿using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Configurations
{
    public class SizeSPConfig : IEntityTypeConfiguration<SizeSP>
    {
        public void Configure(EntityTypeBuilder<SizeSP> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
