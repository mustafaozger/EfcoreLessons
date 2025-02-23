using EfcoreLessons.Infra.Entity.Base;

namespace EfcoreLessons.Infra.Entity
{
    public class ActorEntity:PersonEntity
    {
        public virtual ICollection<MovieEntity> Movies { get; set; }
    }
}
