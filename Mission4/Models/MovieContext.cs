using System;
using Microsoft.EntityFrameworkCore;

namespace Mission4.Models
{
    public class MovieContext : DbContext
    {
        //Constructor
        public MovieContext(DbContextOptions<MovieContext> options) : base (options)
        {
            //Leave blank for now
        }

        public DbSet<MovieEntry> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieEntry>().HasData(

                new MovieEntry
                {
                    MovieId = 1,
                    Category = "Sci-fi/Adventure",
                    Title = "Interstellar",
                    Year = 2014,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Notes = "Love the brain stretch!"
                },

                new MovieEntry
                {
                    MovieId = 2,
                    Category = "Action/Adventure",
                    Title = "Thor: Ragnarok",
                    Year = 2017,
                    Director = "Taika Waititi",
                    Rating = "PG-13",
                    Notes = "Laughed so hard"
                },

                new MovieEntry
                {
                    MovieId = 3,
                    Category = "Drama/Comedy",
                    Title = "Miracle in Cell No. 7",
                    Year = 2013,
                    Director = "Lee Hwan-Kyung",
                    Rating = "PG-13",
                    Notes = "Cried so hard"
                }

                ) ;
        }
    }
}
