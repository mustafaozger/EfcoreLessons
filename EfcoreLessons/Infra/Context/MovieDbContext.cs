using EfcoreLessons.Infra.Entity;
using EfcoreLessons.Infra.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace EfcoreLessons.Infra.Context
{
    public class MovieDbContext:DbContext
    {
        public MovieDbContext(DbContextOptions options):base(options){
        }
        public MovieDbContext(){
            
        } 
        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<ActorEntity> Actors { get; set; }   
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<DirectorEntity> Directors { get; set; }

        // Sen bir model oluşturuyorken database modeli için bir bir şeyleri burada oluşturabiliriz
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Önceden schema isimlerini belirtiyorduk ama şimdi default olarak ef yaptık
            modelBuilder.HasDefaultSchema("ef");

            //Model oluştururulurken hani konfigurasyonların kullanacağını belirtebiliriz
            //Burada mesela MovieEntityConfiguration gibi IEntityTypeConfiguration<T> arayüzünü uygulayan tüm sınıfları bulup, EF Core’un modelBuilder nesnesine ekler.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieEntityConfiguration).Assembly);
        }

        //Hangi database ye bağlanamasını gerektiğini söylemiyorsa bu metodla override edebiliriz
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /* BU şekilde burada da tanımlama yapabiliriz ama bunun yerine 
                DbContextFactory ile daha iyi bir şekilde yapılabilir
            

            if(optionsBuilder.IsConfigured)
                return;
            var configuration= new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var conStt=configuration.GetConnectionString("SqlServer");

            optionsBuilder.UseSqlServer(conStt,options=>
                {
                  options.CommandTimeout(5000);
                  options.EnableRetryOnFailure(maxRetryCount:5);  
                });
                */
        }

    }
}