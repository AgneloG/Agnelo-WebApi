using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerWithWebApi.DataAccess.Repository
{
    public interface IRepositoryFactory
    {
        T GetDataRepository<T>() where T : IRepository, new();// TODO: Remove new
    }
}
