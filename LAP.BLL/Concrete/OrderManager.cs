using LAP.BLL.Abstract;
using LAP.DAL.Abstract;
using LAP.ENTITIES;

namespace LAP.BLL.Concrete
{
    public class OrderManager : BaseManager<Order>, IOrderManager
    {
        public OrderManager(IRepository<Order> repo) : base(repo)
        {

        }
    }
}
