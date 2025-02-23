using EfcoreLessons.Infra.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcoreLessons.Infra.EntityTypeConfigurations
{
    public class BaseEntityTypeConfiguration<TEntity> : 
        IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime2").ValueGeneratedOnAdd();
            builder.Property(e => e.ModifiedDate).HasColumnType("datetime2").IsRequired(false);
            
        }
    }
}
