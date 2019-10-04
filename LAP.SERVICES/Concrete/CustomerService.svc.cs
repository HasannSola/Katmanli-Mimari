
using LAP.DAL.Concrete;
using LAP.SERVICES.Entities;
using LAP.SERVICES.Interfaces;
using System;
using System.Collections.Generic;

namespace LAP.SERVICES.Concrete
{
    public class CustomerService : ICustomerService
    {
        Repository<CustomerModel> repo = new Repository<CustomerModel>();
        public List<CustomerModel> GetAll() => repo.GetAll(null);

    
    }
}
