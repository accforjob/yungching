using interview_yungching.Models;
using interview_yungching.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interview_yungching.DataAccess
{
    public interface ICustomerDA
    {
        Customer GetCustomer(string customerId);

        bool CreateCustomer(CustomerRequest customer);

        bool UpdateCustomer(CustomerRequest customer);

        bool DeleteCustomer(string customerId);

        bool ExistCustomer(string customerId);

    }
}
