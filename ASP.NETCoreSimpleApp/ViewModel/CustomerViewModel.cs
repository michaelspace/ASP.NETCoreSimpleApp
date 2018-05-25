using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETCoreSimpleApp.Data.Model;

namespace ASP.NETCoreSimpleApp.ViewModel
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }

        public int MovieCount { get; set; }
    }
}