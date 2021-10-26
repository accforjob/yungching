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

        public bool CreateCustomer(CustomerRequest customer)
        {
            //有重複的Id直接回false
            if (_customerDA.ExistCustomer(customer.CustomerId))
                return false;

            return _customerDA.CreateCustomer(customer);
        }

        public bool DeleteCustomer(string customerId)
        {
            return _customerDA.DeleteCustomer(customerId);
        }

        public Customer GetCustomer(string customerId)
        {
            return _customerDA.GetCustomer(customerId);
        }

        public bool UpdateCustomer(CustomerRequest customer)
        {
            return _customerDA.UpdateCustomer(customer);
        }
    }
}
