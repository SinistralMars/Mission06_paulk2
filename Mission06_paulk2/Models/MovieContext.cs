using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_paulk2.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {
            //Leave blank for now
        }

        public DbSet<ApplicationResponse> Responses { get; set; }

        //Some seeded movies
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(
                
                new ApplicationResponse
                {
                    MovieId = 1,
                    Category = "Action/Adventure",
                    Title = "Avengers, The",
                    Year = 2012,
                    Director = "Joss Whedon",
                    Rating = "PG-13",
                    Edited = false
                },
                new ApplicationResponse
                {
                    MovieId = 2,
                    Category = "Action/Adventure",
                    Title = "Batman",
                    Year = 1989,
                    Director = "Tim Burton",
                    Rating = "PG-13",
                    Edited = false
                },
                new ApplicationResponse
                {
                    MovieId = 3,
                    Category = "Action/Adventure",
                    Title = "Batman & Robin",
                    Year = 1997,
                    Director = "Joel Schumacher",
                    Rating = "PG-13",
                    Edited = false
                }
                );
        }
    }
}
