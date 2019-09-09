using LAP.BLL.Abstract;
using LAP.DAL.Abstract;
using LAP.ENTITIES;

namespace LAP.BLL.Concrete
{
    public class CustomerManager : BaseManager<Customer>, ICustomerManager
    {
        public CustomerManager(IRepository<Customer> repo) : base(repo)
        {

        }
    }
}
