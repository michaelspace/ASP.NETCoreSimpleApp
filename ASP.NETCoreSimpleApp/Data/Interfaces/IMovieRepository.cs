using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETCoreSimpleApp.Data.Model;

namespace ASP.NETCoreSimpleApp.Data.Interfaces
{
    public interface IMovieRepository: IRepository<Movie>
    {
        IEnumerable<Movie> GetAllWithDirector();

        IEnumerable<Movie> FindWithDirector(Func<Movie, bool> predicate);

        IEnumerable<Movie> FindWithDirectorAndCustomer(Func<Movie, bool> predicate);
    }
}
