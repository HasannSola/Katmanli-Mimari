using CustomerService;
using LAP.BLL.Abstract;
using LAP.CORE.Enum;
using LAP.ENTITIES;
using LAP.ENTITIES.CustomModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService;

namespace LAP.MVC.Controllers
{
    [Route("musteri/")]
    [Produces("application/json")]
    public class CustomerController : Controller
    {
        private readonly ICustomerManager _customerManager;
        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }


        private async Task<List<User>> UserService()
        {
            UserServiceClient _userService = new UserServiceClient();
            var list = await _userService.GetAllAsync();
            return JsonConvert.DeserializeObject<List<User>>(list);
        }
        private async Task<List<Customer>> CustomerService()
        {
            CustomerServiceClient _customerService = new CustomerServiceClient();
            var list = await _customerService.GetAllAsync();
            return JsonConvert.DeserializeObject<List<Customer>>(list);
        }

        [HttpGet("liste")]
        [HttpGet("~/")]
        public ActionResult Customer_List()
        {

            return View();
        }

        [HttpGet("list/data")]
        public async Task<JsonResult> Customer_Data(bool IsServis = false)
        {
            try
            {
                List<Customer> customerList = new List<Customer>();
                if (IsServis)
                {
                    customerList = (await CustomerService()).Where(d => d.InStatus == (int)StatusInfo.Active).OrderBy(c=>c.FlBalance).ToList();
                    //await UserService();
                }
                else
                {
                    customerList = _customerManager.GetAll().Where(d => d.InStatus == (int)StatusInfo.Active).OrderBy(c => c.StName).ToList();
                }


                return Json((object)new
                {
                    data = customerList,
                    message = "OK",
                    success = true,
                    redirectUrl = "",
                });
            }
            catch (Exception ex)
            {
                return Json((object)new
                {
                    data = 0,
                    message = "Hata oluştu : " + ex.Message,
                    success = false,
                    redirectUrl = "",
                });
            }
        }

        [HttpPost("kaydet")]
        public JsonResult Customer_CreateUpdate([FromBody]Customer customer)//FormBody müşteri bilgisi Http Body kısmında taşındığını gösterir.
        {
            CResult<Customer> result = new CResult<Customer>();
            if (ModelState.IsValid)
            {
                if (customer.InCustomerId > 0)
                    result = _customerManager.Update(customer);
                else
                    result = _customerManager.Add(customer);
            }
            else
            {
                result.Desc = string.Join(";</br> ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
            }

            return Json((object)new
            {
                data = 0,
                message = result.Desc,
                success = result.Succeeded,
                redirectUrl = "",
            });
        }

        [HttpPost("sil/{id}")]
        public JsonResult Customer_Delete(int id = 0)
        {
            CResult<string> result = _customerManager.Delete(id);
            return Json((object)new
            {
                data = 0,
                message = result.Desc,
                success = result.Succeeded,
                redirectUrl = "",
            });
        }
    }
}