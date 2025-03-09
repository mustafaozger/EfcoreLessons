using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfcoreLessons.Infra.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcoreLessons.Infra.EntityTypeConfigurations
{
    public class AuditLogEntityConfiguration:BaseEntityTypeConfiguration<AuditLogEntity>
    {
        public override void Configure(EntityTypeBuilder<AuditLogEntity> builder)
        {
            builder.ToTable(name:"AuditLogs",schema:"ef");
            base.Configure(builder);
        }
    }
}