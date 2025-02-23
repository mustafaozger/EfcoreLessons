namespace EfcoreLessons.Infra.Entity.Base
{
    public abstract class PersonEntity:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
