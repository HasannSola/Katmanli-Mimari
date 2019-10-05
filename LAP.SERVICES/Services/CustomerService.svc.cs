using LAP.DAL.Concrete;
using LAP.ENTITIES;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LAP.SERVICES.Services
{
    public class CustomerService : ICustomerService
    {
        Repository<Customer> repo = new Repository<Customer>();
        public string GetAll()
        {
            List<Customer> list = repo.GetAll(null);
            if (repo != null)
                list = repo.GetAll(null);
            return JsonConvert.SerializeObject(list);
        }
    }
}
