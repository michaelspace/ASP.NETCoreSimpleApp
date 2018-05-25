using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETCoreSimpleApp.Data.Interfaces;
using ASP.NETCoreSimpleApp.Data.Model;
using ASP.NETCoreSimpleApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreSimpleApp.Controllers
{
    public class CustomerController: Controller
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMovieRepository movieRepository;

        public CustomerController(ICustomerRepository customer, IMovieRepository movie)
        {
            customerRepository = customer;
            movieRepository = movie;
        }

        #region List implementation
        [Route("Customer")]
        public IActionResult List()
        {
            var customers = customerRepository.GetAll();

            var customerList = new List<CustomerViewModel>();

            if (customers.Count() == 0)
            {
                return View("Empty");
            }

            foreach (var customer in customers)
            {
                customerList.Add(new CustomerViewModel
                {
                    Customer = customer,
                    MovieCount = movieRepository.Count(x => x.CustomerId == customer.CustomerId)

                });
            }

            return View(customerList);
        }
        #endregion

        #region Delete implementation
        public IActionResult Delete(int id)
        {
            var customer = customerRepository.GetById(id);
            customerRepository.Delete(customer);

            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            customerRepository.Create(customer);

            return RedirectToAction("List");
        }
        #endregion

        #region Update implementation
        public IActionResult Update(int id)
        {
            var customer = customerRepository.GetById(id);

            return View(customer);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            customerRepository.Update(customer);

            return RedirectToAction("List");
        }
        #endregion
    }
}
