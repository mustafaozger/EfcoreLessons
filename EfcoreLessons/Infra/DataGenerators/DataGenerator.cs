using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using EfcoreLessons.Infra.Entity;

namespace EfcoreLessons.Infra.DataGenerators
{
    public abstract class DataGenerator
    {
        public static List<MovieEntity> GenerateMovies(int count){
            var locale="tr";
            var genreFaker= new Faker<GenreEntity>(locale)
                .RuleFor(g=>g.Id,f=>Guid.NewGuid())
                .RuleFor(g=>g.CreatedDate,f=>f.Date.Past(3))
                .RuleFor(g=>g.ModifiedDate,f=>f.Date.Past(2))
                .RuleFor(g=>g.Name,f=>f.Music.Genre());


            var directorFaker=new Faker<DirectorEntity>(locale)
                .RuleFor(d=>d.Id,f=>Guid.NewGuid())
                .RuleFor(d=>d.FirstName,f=>f.Name.FirstName())
                .RuleFor(d=>d.LastName,f=>f.Name.LastName())
                .RuleFor(d=>d.CreatedDate,f=>f.Date.Past(5))
                .RuleFor(d=>d.ModifiedDate,f=>f.Date.Past(2));

            var actorFaker=new Faker<ActorEntity>(locale)
                .RuleFor(d=>d.Id,f=>Guid.NewGuid())
                .RuleFor(d=>d.FirstName,f=>f.Name.FirstName())
                .RuleFor(d=>d.LastName,f=>f.Name.LastName())
                .RuleFor(d=>d.CreatedDate,f=>f.Date.Past(5))
                .RuleFor(d=>d.ModifiedDate,f=>f.Date.Past(2))
                .RuleFor(d=>d.Movies,f=>[ ]);

            var genres=genreFaker.Generate(5);
            var director=directorFaker.Generate(5);
            var actors=actorFaker.Generate(20);

            var movieFaker=new Faker<MovieEntity>(locale)
                .RuleFor(d=>d.Id,f=>Guid.NewGuid())
                .RuleFor(d=>d.Name,f=>f.Lorem.Sentence(2))
                .RuleFor(d=>d.CreatedDate,f=>f.Date.Past(5))
                .RuleFor(d=>d.ModifiedDate,f=>f.Date.Past(2))
                .RuleFor(m=>m.DirectorID,f=>f.PickRandom(director).Id)
                .RuleFor(m=>m.GenreID,f=>f.PickRandom(genres).Id)
                .RuleFor(m=>m.Director,f=>f.PickRandom(director))
                .RuleFor(m=>m.Genre,f=>f.PickRandom(genres))
            .RuleFor(m => m.Actors, f => f.PickRandom(actors, f.Random.Int(2, 5)).ToList());
            var movies=movieFaker.Generate(count);
            
            return movies;
        } 
        
    }
}