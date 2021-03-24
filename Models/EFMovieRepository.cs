using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    //Inherit from IBooksRepository
    public class EFMovieRepository : iMovieRepository
    {

        private MovieDbContext _context;

        //Contsructor that receives an MovieDBContext object as a parameter and sets context to the private variable
        public EFMovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public IQueryable<Movie> Movies => _context.Movies;
    }
}
