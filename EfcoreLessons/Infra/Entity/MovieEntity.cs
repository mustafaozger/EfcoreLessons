using EfcoreLessons.Infra.Entity.Base;

namespace EfcoreLessons.Infra.Entity
{
    public class MovieEntity:BaseEntity
    {
        public string Name { get; set; }
        public int ViewCount  { get; set; }
        public Guid GenreID { get; set; }
        public Guid DirectorID { get; set; }

        public virtual DirectorEntity Director { get; set; }
        public virtual GenreEntity Genre { get; set; }
        public virtual ICollection<ActorEntity> Actors { get; set; }

    }
}
