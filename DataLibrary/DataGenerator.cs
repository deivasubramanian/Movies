using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class DataGenerator
    {

        public static void Seed(MovieDataContext context)
        {
            if (context.Movies.Any())
            {
                return;
            }
            context.Movies.AddRange(
                new Models.Movie
                {
                    Year = 2021,
                    Title = "Don't look up",
                    Duration = 2,
                    Popularity = 1,
                    Rating = 2,
                    Comments = new List<Comments>()

                },
               new Models.Movie
               {
                   Year = 2020,
                   Title = "Test film ",
                   Duration = 3,
                   Popularity = 1,
                   Rating = 2,
                   Comments = new List<Comments>()
               },
               new Models.Movie
               {
                   Duration = 1,
                   Title = "Agent of the new world",
                   Popularity = 4,
                   Rating = 4,
                   Year = 2001,
                   Comments = new List<Comments>()
               }); ;



        }
    
        public static void Initialize(IServiceProvider serviceProvider)
        {
        using (var context = new MovieDataContext(
            serviceProvider.GetRequiredService<DbContextOptions<MovieDataContext>>()))
        {
            if (context.Movies.Any())
            {
                return;
            }

                context.Movies.AddRange(
                    new Models.Movie
                    {
                        Year = 2021,
                        Title = "Don't look up",
                        Duration = 2,
                        Popularity = 1,
                        Rating = 3,
                      

                    },
                   new Models.Movie
                   {
                       Year = 2020,
                       Title = "Test film ",
                       Duration = 3,
                       Popularity = 1,
                       Rating = 2,

                     
                   },
                   new Models.Movie
                   {
                       Duration = 1,
                       Title = "Agent of the new world",
                       Popularity = 4,
                       Rating = 4,
                       Year = 2001,

                   }); ;

               
                context.SaveChanges();
                
            }
        }
    }
}

