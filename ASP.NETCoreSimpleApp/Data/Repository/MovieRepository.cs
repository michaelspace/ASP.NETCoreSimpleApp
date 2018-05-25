using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETCoreSimpleApp.Data.Interfaces;
using ASP.NETCoreSimpleApp.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreSimpleApp.Data.Repository
{
    public class MovieRepository: Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieRentalDbContext context) : base(context)
        {
        }

        public IEnumerable<Movie> GetAllWithDirector()
        {
            return context.Movies.Include(p => p.Director);
        }

        public IEnumerable<Movie> FindWithDirector(Func<Movie, bool> predicate)
        {
            return context.Movies.Include(p => p.Director).Where(predicate);
        }

        public IEnumerable<Movie> FindWithDirectorAndCustomer(Func<Movie, bool> predicate)
        {
            return context.Movies.Include(p => p.Director).Include(p => p.Customer).Where(predicate);
        }
    }
}
