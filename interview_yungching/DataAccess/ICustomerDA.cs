using interview_yungching.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interview_yungching.DataAccess
{
    public interface ICustomerDA
    {
        Customer GetCustomer(string customerId);

        bool CreateCustomer(Customer customer);

        bool UpdateCustomer(Customer customer);

        bool DeleteCustomer(string customerId);

    }
}
