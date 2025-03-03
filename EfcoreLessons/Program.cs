
using EfcoreLessons.Infra.Context;
using EfcoreLessons.Infra.DataGenerators;
using Microsoft.EntityFrameworkCore;
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
await dbContext.Database.EnsureCreatedAsync();
optionsBuilder.UseAsyncSeeding(async(context,useASync,ct)=>
{   
    var movieExists= await dbContext.Movies.AnyAsync(ct); 
    var moies=DataGenerator.GenerateMovies(10);
    dbContext.Movies.AddRange(moies);
    await dbContext.SaveChangesAsync(ct);

});



 