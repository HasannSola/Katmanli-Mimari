using System.ServiceModel;

namespace LAP.SERVICES.Services
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        string GetAll();
    }
}
