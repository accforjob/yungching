using interview_yungching.Contexts;
using interview_yungching.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interview_yungching.DataAccess
{
    public class CustomerDA : ICustomerDA
    {
        private readonly MyDBContext _myDBContext;
        public CustomerDA(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }

        public bool CreateCustomer(Customer customer)
        {
            _myDBContext.Add(customer);
            return _myDBContext.SaveChanges() > 0;
        }

        public bool DeleteCustomer(string customerId)
        {
            var customer = _myDBContext.Customers.Find(customerId);
            _myDBContext.Customers.Remove(customer);
            return _myDBContext.SaveChanges() > 0;
        }

        public Customer GetCustomer(string customerId)
        {
            return _myDBContext.Customers.Where(p => p.CustomerId == customerId).FirstOrDefault();
        }

        public bool UpdateCustomer(Customer customer)
        {
            var dbCustomer = _myDBContext.Customers.FirstOrDefault(p => p.CustomerId == customer.CustomerId);
            _myDBContext.Entry(dbCustomer).CurrentValues.SetValues(customer);
            return _myDBContext.SaveChanges() > 0;
        }


    }
}
