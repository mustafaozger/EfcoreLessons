using System;
using EfcoreLessons.Infra.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcoreLessons.Infra.EntityTypeConfigurations;

public class GenreEntityConfiguration:BaseEntityTypeConfiguration<GenreEntity>
{
    public override void Configure(EntityTypeBuilder<GenreEntity> builder)
    {
        builder.ToTable(name:"Genres",schema:"ef");
        
        base.Configure(builder);
    }
}
