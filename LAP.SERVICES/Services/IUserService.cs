using System.ServiceModel;

namespace LAP.SERVICES.Services
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        string GetAll();
    }
}
