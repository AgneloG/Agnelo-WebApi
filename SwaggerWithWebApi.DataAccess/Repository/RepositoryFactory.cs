using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerWithWebApi.DataAccess.Repository
{
    public class RepositoryFactory : IRepositoryFactory
    {
        

        public T GetDataRepository<T>() where T : IRepository, new()
        {
            return new T();
        }
    }
}
