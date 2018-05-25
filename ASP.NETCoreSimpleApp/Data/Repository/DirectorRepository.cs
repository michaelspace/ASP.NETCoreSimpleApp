using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETCoreSimpleApp.Data.Interfaces;
using ASP.NETCoreSimpleApp.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreSimpleApp.Data.Repository
{
    public class DirectorRepository: Repository<Director>, IDirectorRepository
    {
        public DirectorRepository(MovieRentalDbContext context) : base(context)
        {

        }

        public IEnumerable<Director> GetAllWithMovies()
        {
            return context.Directors.Include(p => p.Movies);
        }

        public Director GetWithMovies(int id)
        {
            return context.Directors.Where(p => p.DirectorId == id).Include(p => p.Movies).FirstOrDefault();
        }
    }
}
