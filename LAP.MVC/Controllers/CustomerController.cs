using LAP.BLL.Abstract;
using LAP.CORE.Enum;
using LAP.ENTITIES;
using LAP.ENTITIES.CustomModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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

        [HttpGet("liste")]
        [HttpGet("~/")]
        public ActionResult Customer_List()
        {
            return View();
        }

        [HttpGet("list/data")]
        public JsonResult Customer_Data()
        {
            try
            {
                var list = _customerManager.GetAll().Where(d => d.InStatus == (int)StatusInfo.Active).Select(_customer => new
                {
                    InCustomerId = _customer.InCustomerId,
                    StName = _customer.StName,
                    FlBalance = _customer.FlBalance,
                    StDescription = _customer.StDescription,
                }).ToList();

                return Json((object)new
                {
                    data = list,
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