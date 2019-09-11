using LAP.BLL.Abstract;
using LAP.CORE.Enum;
using LAP.ENTITIES;
using LAP.ENTITIES.CustomModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _customerManager;
        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        // http://localhost:5000/api/customer
        [HttpGet]
        public ActionResult<List<Customer>> Gets()
        {
            return _customerManager.GetAll(c => c.InStatus == (int)StatusInfo.Active);
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