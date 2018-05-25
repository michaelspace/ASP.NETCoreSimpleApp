using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETCoreSimpleApp.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ASP.NETCoreSimpleApp.Data
{
    public class InitializeDb
    {
        public static void InitializeData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MovieRentalDbContext>();

                // Add customers
                var max = new Customer {Name = "Max Stark"};
                var alice = new Customer {Name = "Alice Richards"};
                var flora = new Customer {Name = "Flora Benz"};
                var tonny = new Customer {Name = "Tonny Smith"};

                context.Customers.Add(max);
                context.Customers.Add(alice);
                context.Customers.Add(flora);
                context.Customers.Add(tonny);

                // Add directors
                var william = new Director
                {
                    Name = "William Cruz",
                    Movies = new List<Movie>
                    {
                        new Movie {Title = "Road Trip"},
                        new Movie {Title = "Dreams Come True"},
                        new Movie { Title = "Some fun Commedy"}
                    }
                };
                var andrea = new Director
                {
                    Name = "Andrea Douglas",
                    Movies = new List<Movie>
                    {
                        new Movie {Title = "Mystery"},
                        new Movie {Title = "Another Scary Horror"},
                        new Movie { Title = "Across the River"},
                        new Movie {Title = "The Circle"}
                    }
                };

                context.Directors.Add(william);
                context.Directors.Add(andrea);

                // Save changes
                context.SaveChanges();
            }
        }
    }
}
