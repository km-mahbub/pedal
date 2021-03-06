﻿using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Data.EntityTypeConfiguration
{
    class ManagerLoginHistoryConfiguration: EntityTypeConfiguration<ManagerLoginHistory>
    {
        public ManagerLoginHistoryConfiguration()
        {
            Property(m => m.LoginTime)
                .IsRequired();
            Property(m => m.LoginTime)
                .IsRequired();
            Property(a => a.IsDeleted)
                .HasColumnAnnotation("Default", false);
        }

    }
}
