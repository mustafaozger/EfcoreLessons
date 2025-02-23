using System;
using EfcoreLessons.Infra.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcoreLessons.Infra.EntityTypeConfigurations;

public class ActorEntityConfiguration
    :PersonBaseEntityTypeConfigurations<ActorEntity>
{
    public override void Configure(EntityTypeBuilder<ActorEntity> builder)
    {
        builder.ToTable(name:"Actors",schema:"ef");
       // builder.Property(i=>i.Email).IsRequired(false).HasMaxLength(42);
   /*     builder.HasMany(a=> a.Movies)
                .WithMany(m=>m.Ac tors)
                .UsingEntity(j=>j.ToTable("ActorMovie"));
*/
        base.Configure(builder);
    }
}
