using LAP.BLL.Abstract;
using LAP.DAL.Abstract;
using LAP.ENTITIES;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAP.BLL.Concrete
{
   public class UserManager : BaseManager<User>, IUserManager
    {
        public UserManager(IRepository<User> repo) : base(repo)
        {

        }
    }
}
