using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EfcoreLessons.Infra.Context
{
    //Eğer design time da context factory e  ihtiyaç varsa bu şekilde de oluşutrabiliriz
    public class DbContextFactory : IDesignTimeDbContextFactory<MovieDbContext>
    {
        public MovieDbContext CreateDbContext(string[] args)
        {
            var configuration=new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var conStr= configuration.GetConnectionString("SqlServer");

            var options=new DbContextOptionsBuilder();
            options.UseSqlServer(conStr,builder=>{
                builder.CommandTimeout(5000);
            
            });
            return new MovieDbContext(options.Options);
        }
    }
}