using EfcoreLessons.Infra.Context;
using EfcoreLessons.Infra.Entity;
using Microsoft.EntityFrameworkCore;

namespace EfcoreLessons.Infra.Repositories
{
    public class MovieRepository(MovieDbContext dbContext)
    {
        public async Task AddMovie(MovieEntity movie)
        {
            if(await dbContext.Movies.AnyAsync(i=>i.Name.Equals(movie.Name)))
                throw new Exception("Movie already exists");
            dbContext.Add(movie);
            await dbContext.SaveChangesAsync();
        }
    }
}