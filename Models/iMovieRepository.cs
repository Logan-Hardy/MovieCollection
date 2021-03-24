using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public interface iMovieRepository
    {
        //Allows user to obtain a sequence of Movie objects
        IQueryable<Movie> Movies { get; }

    }
}
