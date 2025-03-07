using System;
using EfcoreLessons.Infra.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcoreLessons.Infra.EntityTypeConfigurations;

public class MovieEntityConfiguration: BaseEntityTypeConfiguration<MovieEntity>
{
    public override void Configure(EntityTypeBuilder<MovieEntity> builder)
    {
        builder.ToTable(name : "Movies",schema: "ef");

        builder.Property(p=>p.Name).IsRequired().HasMaxLength(200);
        builder.Property(p=> p.ViewCount).HasDefaultValue(1);

    // One-To-Many => Directory
        builder.HasOne(d=> d.Director).WithMany(m=>m.Movies).HasForeignKey(m=>m.DirectorID);
        // One-To-Many => Genre
        builder.HasOne(m => m.Genre).WithMany(m=>m.Movies).HasForeignKey(m=>m.GenreID);
        // Many-2-Many => Actors
        builder.HasMany(a=>a.Actors).WithMany(m=>m.Movies).UsingEntity(j=> j.ToTable("MovieActors"));

        //Owned Types
        builder.OwnsOne(p=>p.Release);

        builder.OwnsMany(p=>p.ReleaseCinemas, builder=>
            {
                builder.ToTable("MovieReleaseCinemas");
                builder.Property(p=>p.Name).HasMaxLength(200);
                builder.Property(p=>p.AdresLine1).HasMaxLength(200).IsRequired();
                builder.Property(p=>p.AdresLine2).IsRequired(false);
            });

        builder.Property(p=>p.RowVersion).IsRowVersion();

        base.Configure(builder);


    }

}
