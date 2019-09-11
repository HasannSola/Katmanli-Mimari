using LAP.BLL.Abstract;
using LAP.CORE.Enum;
using LAP.DAL.Abstract;
using LAP.ENTITIES;
using LAP.ENTITIES.CustomModels;
using System;
using System.Threading.Tasks;

namespace LAP.BLL.Concrete
{
    public class CustomerManager : BaseManager<Customer>, ICustomerManager
    {
        public CustomerManager(IRepository<Customer> repo) : base(repo)
        {

        }

        public override CResult<Customer> Update(Customer entity)
        {
            entity.InStatus = (int)StatusInfo.Active;
            entity.DtUpdateTime = DateTime.Now;
            return base.Update(entity); 
        }
   
        public override CResult<Customer> Add(Customer entity)
        {
            entity.InStatus = (int)StatusInfo.Active;
            entity.DtCreateTime = DateTime.Now;
            return base.Add(entity);
        }
        public override Task<CResult<Customer>> AddAsync(Customer entity)
        {
            entity.InStatus = (int)StatusInfo.Active;
            entity.DtCreateTime = DateTime.Now;
            return base.AddAsync(entity);
        }
    }
}
