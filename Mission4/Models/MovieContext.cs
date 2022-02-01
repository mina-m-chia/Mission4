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

        public DbSet<Category> Categories { get; set; }

        //Seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(

                new Category { CategoryId = 1, CategoryName="Sci-fi/Adventure"},
                new Category { CategoryId = 2, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 3, CategoryName = "Drama/Comedy" },
                new Category { CategoryId = 4, CategoryName = "Comedy" },
                new Category { CategoryId = 5, CategoryName = "Drama" },
                new Category { CategoryId = 6, CategoryName = "Family" },
                new Category { CategoryId = 7, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 8, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 9, CategoryName = "Television" },
                new Category { CategoryId = 10, CategoryName = "VHS" }

                );

            mb.Entity<MovieEntry>().HasData(

                new MovieEntry
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "Interstellar",
                    Year = 2014,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Notes = "Love the brain stretch!"
                },

                new MovieEntry
                {
                    MovieId = 2,
                    CategoryId = 2,
                    Title = "Thor: Ragnarok",
                    Year = 2017,
                    Director = "Taika Waititi",
                    Rating = "PG-13",
                    Notes = "Laughed so hard"
                },

                new MovieEntry
                {
                    MovieId = 3,
                    CategoryId = 3,
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
