using interview_yungching.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interview_yungching.Services
{
    public interface ICustomerService
    {
        Customer GetCustomer(string customerId);

        bool CreateCustomer(CustomerRequest customer);

        bool UpdateCustomer(CustomerRequest customer);

        bool DeleteCustomer(string customerId);
    }
}
