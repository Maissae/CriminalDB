﻿using CriminalDB.Core.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Persistence.Configuration
{
    public class CriminalConfiguration : PersonConfiguration<Criminal>
    {
        public override void Configure(EntityTypeBuilder<Criminal> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
        }
    }
}
