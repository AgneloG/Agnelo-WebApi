using System;
using System.Threading.Tasks;

namespace SwaggerWithWebApi.DataAccess.Repository
{
    public interface IUnitOfWork //: IDisposable
    {
        //Task<int> CompleteAsync();
        Repository.IEmployeeRepository EmployeeRepo { get; }
    }
}