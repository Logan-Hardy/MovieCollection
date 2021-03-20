using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            MovieDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<MovieDbContext>();

            //run migrations if needed
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //add hardcoded entries if there aren't any contents already
            if (!context.Movies.Any())
            {

                context.Movies.AddRange(

                    new Movie
                    {
                        MovieTitle = "Ready Player One", 
                        Category = "Action/Adventure/Sci-fi",
                        Year = "2018",
                        Director = "Steven Spielberg",
                        Rating = "PG-13",
                        Notes = "See how many easter eggs you can find!"
                    },
                    new Movie
                    {
                        MovieTitle = "Captain America: The First Avenger",
                        Category = "Action/Adventure",
                        Year = "2011",
                        Director = "Joe Johnston",
                        Rating = "PG-13",
                        Notes = "A story of a true patriot."
                    },
                    new Movie
                    {
                        MovieTitle = "Juarassic Park",
                        Category = "Action/Adventure",
                        Year = "1993",
                        Director = "Steven Spielberg",
                        Rating = "PG-13",
                        Notes = "Dinos and stuff"
                    },
                    new Movie
                    {
                        MovieTitle = "Live Die Repeat: Edge of Tomorrow",
                        Category = "Action/Adventure",
                        Year = "2014",
                        Director = "Doug Liman",
                        Rating = "PG-13",
                        Notes = "Groundhog Day with action and Tom Cruise"
                    },
                    new Movie
                    {
                        MovieTitle = "The Matrix",
                        Category = "Action/Adventure",
                        Year = "1999",
                        Director = "The Wachowski Brothers",
                        Rating = "R",
                        Notes = "Which pill would you take?"
                    },
                    new Movie
                    {
                        MovieTitle = "Back to the Future",
                        Category = "Comedy",
                        Year = "1985",
                        Director = "Robert Zemeckis",
                        Rating = "PG"
                        
                    },
                    new Movie
                    {
                        MovieTitle = "Clue",
                        Category = "Comedy",
                        Year = "1985",
                        Director = "Johnathan Lynn",
                        Rating = "PG",
                        Notes = "Who doesn't like Tim Curry?"
                    },
                    new Movie
                    {
                        MovieTitle = "Love Actually",
                        Category = "Comedy",
                        Year = "2003",
                        Director = "Richard Curtis",
                        Rating = "R",
                        Edited = true
                        
                    },
                    new Movie
                    {
                        MovieTitle = "The Phantom of the Opera",
                        Category = "Drama",
                        Year = "2005",
                        Director = "Joel Schumacher",
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        MovieTitle = "Aladdin",
                        Category = "Family",
                        Year = "1992",
                        Director = "Ron Clements, John Musker",
                        Rating = "G",
                        Notes = "No one else like Robin Williams"
                    },
                    new Movie
                    {
                        MovieTitle = "The Goonies",
                        Category = "Family",
                        Year = "1985",
                        Director = "Richard Donner",
                        Rating = "PG",
                        Notes = "Check out Sean Astin when he was young!"
                    },
                    new Movie
                    {
                        MovieTitle = "The Sixth Sense",
                        Category = "Horror/Suspense",
                        Year = "1999",
                        Director = "M. Night Shyamalan",
                        Rating = "PG-13",
                        Notes = "I see dead people..."
                    },
                    new Movie
                    {
                        MovieTitle = "Avatar: The Last Airbender (Book 1)",
                        Category = "Television",
                        Year = "2005",
                        Director = "Michael Dante DiMartino, Bryan Konietzko",
                        Rating = "TV-Y7",
                        Notes = "Cactus juice"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
