using EfcoreLessons.Infra.Entity.Base;

namespace EfcoreLessons.Infra.Entity
{
    public class DirectorEntity:PersonEntity
    {
        public virtual ICollection<MovieEntity> Movies{ get; set; }

    }
}
