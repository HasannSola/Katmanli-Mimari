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

namespace LAP.TEST.UserTest
{
  public  class UserTest
    {
        private IUserManager _userManager;
        public UserTest()
        {
            _userManager = new UserManager(new Repository<User>());
        }

        [Fact]
        public void Initialize()
        {
            try
            {
                int count = 1;
                while(count<=5)
                {
                    var result = _userManager.Add(new User { StUserName = "Ali VELİ ",StEmail="ali.veli@gamil.com",  InStatus = (int)StatusInfo.Active, StDescription = "TEST" });
                    if (result.Succeeded)
                    {
                        count++;
                    }
                    else
                    {
                        throw new Exception("Kayıt Başarısız " +result.Desc);
                    }
                }

                var list = _userManager.GetAll();
                Assert.Equal(5, list.ToList().Count);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
