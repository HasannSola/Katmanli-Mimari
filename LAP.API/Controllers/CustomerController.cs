using LAP.BLL.Abstract;
using LAP.CORE.Enum;
using LAP.DAL.Redis;
using LAP.ENTITIES;
using LAP.ENTITIES.CustomModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Redis;
using System.Collections.Generic;
using System.Text;

namespace LAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _customerManager;
        private readonly IRedisContext<Customer> _customerRedisManager;
        public CustomerController(ICustomerManager customerManager, IRedisContext<Customer> customerRedisManager)
        {
            _customerManager = customerManager;
            _customerRedisManager = customerRedisManager;
        }

        // http://localhost:5000/api/customer
        [HttpGet]
        public ActionResult<List<Customer>> Gets()
        {
            return _customerManager.GetAll(c => c.InStatus == (int)StatusInfo.Active);
        }

        // http://localhost:5000/api/customer/redis
        /// <summary>
        /// Redis cacheden customer listeyi getir.
        /// </summary>
        /// <returns></returns>
        [HttpGet("redis")]
        public ActionResult<List<Customer>> GetsWithRedis()
        {
            List<Customer> customerList = _customerRedisManager.Get<List<Customer>>("customers");
            return customerList;
        }

        // http://localhost:5000/api/customer/6
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return _customerManager.Get(id);
        }

        // http://localhost:5000/api/customer
        //HEADERS alanına  Key = Content-Type ,Value=  application/json
        //BODY alanın {InCustomerId: "0", StName: "HaSAN SOLA", FlBalance: 10, StDescription:"TEST"}
        [HttpPost]
        public ActionResult<int> Post([FromBody] Customer entity)
        {
            //Sessionlar daki değerler RedisCache de okunabilir
            var bytes = Encoding.UTF8.GetBytes("hasan");
            HttpContext.Session.Set("UserName", bytes);

            var bytes2 = Encoding.UTF8.GetBytes("sola");
            HttpContext.Session.Set("UserID", bytes2);

            _customerRedisManager.Set("customers", entity, 60);

            CResult<Customer> result = _customerManager.Add(entity);
            return result.Object == null ? 0 : result.Object.InCustomerId;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // http://localhost:5000/api/customer/6
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {

         

            CResult<string> result = _customerManager.Delete(id);
            return result.Desc;
        }
    }
}