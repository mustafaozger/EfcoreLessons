using System;
using System.Reflection.PortableExecutable;
using EfcoreLessons.Infra.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcoreLessons.Infra.EntityTypeConfigurations;

public class DirectorEntityTypeConfiguration
                :PersonBaseEntityTypeConfigurations<DirectorEntity>
{
    public override void Configure(EntityTypeBuilder<DirectorEntity> builder)
    {
        builder.ToTable(name: " Directors", schema: "ef");
        base.Configure(builder);
/*
        //Movies relation // One to many 
        builder.HasMany(d=>d.Movies)
                .WithOne(m=> m.Director)
                .HasForeignKey(m=>m.DirectorID);
        base.Configure(builder);
        */
    }
}
