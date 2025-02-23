using EfcoreLessons.Infra.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcoreLessons.Infra.EntityTypeConfigurations;

public class PersonBaseEntityTypeConfigurations<IEntity>
                : BaseEntityTypeConfiguration<IEntity> where IEntity : PersonEntity
{
    public override void Configure(EntityTypeBuilder<IEntity> builder)
    {
        builder.Property(e=>e.FirstName)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(e=>e.LastName)
            .HasColumnName("LastName")
            .IsRequired()
            .HasMaxLength(100);

        base.Configure(builder);
    }
}
