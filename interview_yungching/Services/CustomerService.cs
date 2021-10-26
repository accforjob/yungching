using interview_yungching.DataAccess;
using interview_yungching.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interview_yungching.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDA _customerDA;
        public CustomerService(ICustomerDA customerDA)
        {
            _customerDA = customerDA;
        }

        public bool CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(string customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(string customerId)
        {
            return _customerDA.GetCustomer(customerId);
        }

        public bool UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
