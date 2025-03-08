using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfcoreLessons.Infra.Context;
using EfcoreLessons.Infra.Entity;
using Microsoft.EntityFrameworkCore;

namespace EfcoreLessons.Infra.Repositories
{
    public class DirectorRepository(MovieDbContext dbContext)
    {
        public async Task AddDirector(DirectorEntity entity)
        {
            if(await IsDirectorExist(entity.Id))
                throw new Exception("Director already exists!");
            dbContext.Add(entity);
            await dbContext.SaveChangesAsync();
        }
        
        public Task<bool> IsDirectorExist(Guid guid)
            => dbContext.Directors.AnyAsync(m=>m.Id==guid);
    }

}