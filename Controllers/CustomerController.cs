using CustomerManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CustomerManagement.Controllers
{
    public class CustomerController : Controller
    {
        private static List<Customer> _customers = new();
        private static int _nextId = 1;

        public IActionResult Index()
        {
            return View(_customers);
        }

        public IActionResult Create()
        {
            return View(new Customer());
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.Id = _nextId++;
                _customers.Add(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                var existingCustomer = _customers.FirstOrDefault(c => c.Id == id);
                if (existingCustomer != null)
                {
                    existingCustomer.Name = customer.Name;
                    existingCustomer.Age = customer.Age;
                    existingCustomer.PostCode = customer.PostCode;
                    existingCustomer.Height = customer.Height;
                }
                return RedirectToAction("Index");
            }
            return View(customer);
        }
    }
}