using EfcoreLessons.Infra.Entity.Base;

namespace EfcoreLessons.Infra.Entity
{
    public class GenreEntity:BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<MovieEntity> Movies { get; set; }
    }
}
