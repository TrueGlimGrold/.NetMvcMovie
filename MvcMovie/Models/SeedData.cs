using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "The Prince of Egypt",
                    ReleaseDate = DateTime.Parse("1998-12-18"),
                    Genre = "Drama",
                    Price = 7.99M,
                    Rating = "PG",
                    ImageName = "Egypt.jpg"
                },
                new Movie
                {
                    Title = "The other side of Heaven",
                    ReleaseDate = DateTime.Parse("2001-12-14"),
                    Genre = "Action",
                    Price = 8.99M,
                    Rating = "PG",
                    ImageName = "Heaven.jpg"
                },
                new Movie
                {
                    Title = "Meet the Mormons",
                    ReleaseDate = DateTime.Parse("2014-12-10"),
                    Genre = "Comedy",
                    Price = 9.99M,
                    Rating = "PG",
                    ImageName = "Meet_Them.jpg"
                }
            );
            context.SaveChanges();
        }
    }
}
