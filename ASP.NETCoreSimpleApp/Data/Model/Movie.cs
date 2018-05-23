using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETCoreSimpleApp.Data.Model
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }

        public virtual Director Director { get; set; }
        public int DirectorId { get; set; }

        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
