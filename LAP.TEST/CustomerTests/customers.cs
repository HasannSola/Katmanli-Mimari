using LAP.BLL.Abstract;
using LAP.BLL.Concrete;
using LAP.CORE.Enum;
using LAP.DAL.Concrete;
using LAP.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LAP.TEST.CustomerTests
{
  public class Customers
    {
        private ICustomerManager _CustomerManager;
        public Customers()
        {
            _CustomerManager = new CustomerManager(new Repository<Customer>());
        }

        [Fact]
        public void Initialize()
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    var result = _CustomerManager.Add(new Customer { StName = "Hasan SOLA " + i, InStatus = (int)StatusInfo.Active, StDescription = "TEST" });
                    if (!result.Succeeded)
                    {
                        break;
                    }
                }
                var list = _CustomerManager.GetAll();
                Assert.Equal(5, list.ToList().Count);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
