using interview_yungching.Models;
using interview_yungching.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interview_yungching.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet("{customerId}")]
        public IActionResult Read(string customerId)
        {
            return Ok(_service.GetCustomer(customerId));
        }

        [HttpPost]
        public IActionResult Create(CustomerRequest customer)
        {
            return Ok(_service.CreateCustomer(customer));
        }

        [HttpPut]
        public IActionResult Update(CustomerRequest customer)
        {
            return Ok(_service.UpdateCustomer(customer));
        }

        [HttpDelete("{customerId}")]
        public IActionResult Delete(string customerId)
        {
            return Ok(_service.DeleteCustomer(customerId));
        }
    }
}
