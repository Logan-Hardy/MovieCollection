using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class MovieDbContext : DbContext
    {
        //Constructor
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        //Pull data from database
        public DbSet<Movie> Movies { get; set; }

    }
}
