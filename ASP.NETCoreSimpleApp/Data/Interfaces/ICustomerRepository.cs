using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETCoreSimpleApp.Data.Model;

namespace ASP.NETCoreSimpleApp.Data.Interfaces
{
    public interface ICustomerRepository: IRepository<Customer>
    {
    }
}
