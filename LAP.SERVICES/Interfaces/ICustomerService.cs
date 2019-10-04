using LAP.ENTITIES;
using System.Collections.Generic;
using System.ServiceModel;


namespace LAP.SERVICES.Interfaces
{
    [ServiceContract]
   public interface ICustomerService
    {
        [OperationContract]
         List<Entities.CustomerModel> GetAll();
    }
}
