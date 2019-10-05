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

namespace LAP.TEST.OrderTest
{
    public class orders
    {
        private IOrderManager _OrderManager;
        private ICustomerManager _CustomerManager;
        public orders()
        {
            _OrderManager = new OrderManager(new Repository<Order>());
            _CustomerManager = new CustomerManager(new Repository<Customer>());
        }

        [Fact]
        public void Initialize()
        {
            try
            {
                Customer customer = _CustomerManager.GetAll().FirstOrDefault();
                if (customer.InCustomerId>0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        var result = _OrderManager.Add(new Order { StProductName = "Masa " + i, FlQuantity = 1, InCustomerId = customer.InCustomerId, InStatus = (int)StatusInfo.Active, StDescription = "TEST" });
                        if (!result.Succeeded)
                        {
                            break;
                        }
                    }
                    var list = _OrderManager.GetAll();
                    Assert.NotEmpty(list);
                }
                else
                {
                    System.Console.WriteLine("Lütfen Önce bir Müşteri Ekleyiniz.");
                    Assert.NotEmpty(null);
                }
            

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
