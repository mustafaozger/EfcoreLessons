
using System.Data;
using System.Threading.Tasks;
using Bogus.DataSets;
using EfcoreLessons.Infra.Context;
using EfcoreLessons.Infra.DataGenerators;
using EfcoreLessons.Infra.Entity;
using EfcoreLessons.Infra.EntityTypeConfigurations;
using EfcoreLessons.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.OpenApi.Extensions;

var configuration=new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var conStr= configuration.GetConnectionString("SqlServer");
/*
var options=new DbContextOptionsBuilder();
options.UseSqlServer(conStr,builder=>{
    builder.CommandTimeout(5000);
});
var DbContext= new MovieDbContext(options.Options);
DbContext.Database.OpenConnection();
*/
var optionsBuilder=new DbContextOptionsBuilder<MovieDbContext>();
optionsBuilder.UseSqlServer(conStr,builder=>{
    builder.CommandTimeout(50000);
    builder.MigrationsHistoryTable("__EfMigrationHistory",schema:"ef");
    //builder.EnableRetryOnFailure(maxRetryCount:5);
     
});

var dbContext=new MovieDbContext(optionsBuilder.Options);


optionsBuilder
    .ConfigureWarnings(warnings =>
    {
        warnings.Ignore(RelationalEventId.ConnectionClosed);
        warnings.Log(RelationalEventId.PendingModelChangesWarning);
    });

optionsBuilder
.LogTo(Log,
       events:
       [
           RelationalEventId.CommandExecuted
       ],
        LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors();
/*await EnsureMovieData();
async Task EnsureMovieData()
{
    var movieExists= await dbContext.Movies.AnyAsync(); 
    if(movieExists)
        return;
    
    var moies=DataGenerator.GenerateMovies(10);
    dbContext.Movies.AddRange(moies);
    await dbContext.SaveChangesAsync();

    

}
*/
void RawSqlExamples()
{
    #region FromSQL

    //int nameLength = 4;
    //int nameLengthMax = 15;
    //var nameLengthSqlParam = new SqlParameter("pLength", 4);

    //// After EF 7 (FormattableString)
    //var movies = dbContext.Movies
    //    //.FromSql($"SELECT * FROM ef.Movies Where LEN(NAME) > {nameLength}")
    //    .FromSql($"SELECT * FROM ef.Movies Where LEN(NAME) > {nameLengthSqlParam}")
    //    .ToList();

    //// Before EF7 (FormattableString)
    //movies = dbContext.Movies
    //   .FromSqlInterpolated($"SELECT * FROM ef.Movies Where LEN(NAME) > {nameLength}")
    //   .ToList();


    //movies = dbContext.Movies
    //    .FromSqlRaw($"SELECT * FROM ef.Movies Where LEN(NAME) > @p0", nameLength)
    //    .Where(m => m.Name.Length < nameLengthMax)
    //    .ToList();

    #endregion

    #region ExecuteSQL

    //string formattableStringV1 = $"""
    //    UPDATE ef.Genres 
    //    SET 
    //        ModifiedDate = GETUTCDATE(), 
    //        Name = 'Drama1' 
    //    WHERE 
    //        Name = 'Drama2'
    //    """;

    //string nameParameterValue = "Drama2";
    //FormattableString formattableStringV2 = $"""
    //    UPDATE ef.Genres 
    //    SET 
    //        ModifiedDate = GETUTCDATE(), 
    //        Name = {nameParameterValue} 
    //    WHERE 
    //        Name = 'Drama1'
    //    """;

    //SqlParameter nameSqlParameter = new("pNameValue", "Drama1");
    //FormattableString formattableStringV3 = $"""
    //    UPDATE ef.Genres 
    //    SET 
    //        ModifiedDate = GETUTCDATE(), 
    //        Name = {nameSqlParameter}
    //    WHERE 
    //        Name = {nameParameterValue}
    //    """;


    //var rows = dbContext.Database.ExecuteSqlRaw(formattableStringV1);

    //// After EF7
    //rows = dbContext.Database.ExecuteSql(formattableStringV2);

    //rows = dbContext.Database.ExecuteSqlInterpolated(formattableStringV3);

    #endregion

    #region SqlQuery

    Guid genreId = Guid.Parse("0B4BB3C3-C491-4203-BC4E-AAD55698B280");
    FormattableString mostViewedMovieByGenreId = $"""
        SELECT 
            AVG(ViewCount) 
        FROM 
            ef.Movies 
        Where 
            GenreId = {genreId}
        """;

    var mostViewedCounts = dbContext.Database
        .SqlQuery<int>(mostViewedMovieByGenreId)
        .ToList();


    FormattableString actorSql = $"""
        SELECT Id, FirstName + ' ' + LastName as FullName, FirstName FROM ef.Actors
        """;

    var models = dbContext.Database.SqlQuery<ActorViewModel>(actorSql).ToList();

    #endregion
}





await dbContext.Database.EnsureCreatedAsync();
optionsBuilder.UseAsyncSeeding(async(context,useASync,ct)=>
{   
    var movieExists= await dbContext.Movies.AnyAsync(ct); 
    var moies=DataGenerator.GenerateMovies(10);
    dbContext.Movies.AddRange(moies);
    await dbContext.SaveChangesAsync(ct);

});

   #region Concurrency Catch
/*
    async Task ConcurrencyTest(){
        try
        {
            var dbContext=new MovieDbContext(optionsBuilder.Options);
            var firstMovie=dbContext.Movies.ToList()[0];
            firstMovie.ViewCount++;
            var rawAffected= await dbContext.SaveChangesAsync();

        }catch(DbUpdateConcurrencyException ex)
        {
            foreach(EntityEntry entry in ex.Entries)
            {
                if(entry.Entity is MovieEntity)
                {
                    throw new NotSupportedException("Don't know how to handle cuncerrency conflict");
                }
                var currentValue=entry.CurrentValues;
                var dbValue=entry.GetDatabaseValues;

            }
        }
    }
*/
    #endregion

    #region Transaction
/*
        using var transaction = dbContext.Database.BeginTransaction();
        try
        {
            var dirRepo=new DirectorRepository(dbContext);
            var movieRepo= new MovieRepository(dbContext);
            var director= new DirectorEntity()
            {
                Id=Guid.NewGuid(),
                FirstName="Mustafa",
                LastName="Özger",
                CreatedDate=DateTime.Now
            };
                    var movie= new MovieEntity()
            {   
                GenreID=dbContext.Movies.First().GenreID,
                DirectorID=dbContext.Movies.First().DirectorID,
                Name="The SC Movie",
                CreatedDate=DateTime.Now
            };

            await dirRepo.AddDirector(director);
            await movieRepo.AddMovie(movie);
            transaction.Commit();

        }catch(Exception ex)
        {
            transaction.Rollback();
        }
*/

    #endregion



    void Log(string message)
{
    var color = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("EFCORE_MESSAGE: {0}", message);
    Console.ForegroundColor = color;
}

Console.ReadLine();

class ActorViewModel
{
    public Guid Id { get; set; }

    public string FullName { get; set; }

}



 