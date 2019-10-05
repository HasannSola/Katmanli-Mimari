using LAP.DAL.Concrete;
using LAP.ENTITIES;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LAP.SERVICES.Services
{
    public class UserService : IUserService
    {
        public string GetAll()
        {
            List<User> list = new List<User>();
            Repository<User> repo = new Repository<User>();
           // System.Diagnostics.Debugger.Launch();
            if (repo != null)
                list = repo.GetAll(null);

            return JsonConvert.SerializeObject(list);
        }
    }
}
