using interview_yungching.Contexts;
using interview_yungching.Models;
using interview_yungching.Services;
using Microsoft.EntityFrameworkCore;
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

        public bool ExistCustomer(string customerId)
        {
            return _myDBContext.Customers.FirstOrDefault(p => p.CustomerId == customerId) != null;
        }

        public bool CreateCustomer(CustomerRequest customer)
        {
            var dbCustomer = _myDBContext.Customers.Attach(new Customer { CustomerId = customer.CustomerId });
            dbCustomer.CurrentValues.SetValues(customer);
            _myDBContext.Entry(dbCustomer.Entity).State = EntityState.Added;

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
            return _myDBContext.Customers.FirstOrDefault(p => p.CustomerId == customerId);
        }

        public bool UpdateCustomer(CustomerRequest customer)
        {
            var dbCustomer = _myDBContext.Customers.FirstOrDefault(p => p.CustomerId == customer.CustomerId);
            _myDBContext.Entry(dbCustomer).CurrentValues.SetValues(customer);
            return _myDBContext.SaveChanges() > 0;
        }


    }
}
