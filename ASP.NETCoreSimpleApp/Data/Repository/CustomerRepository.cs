using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETCoreSimpleApp.Data.Interfaces;
using ASP.NETCoreSimpleApp.Data.Model;

namespace ASP.NETCoreSimpleApp.Data.Repository
{
    public class CustomerRepository: Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MovieRentalDbContext context) : base(context)
        {
        }
    }
}
