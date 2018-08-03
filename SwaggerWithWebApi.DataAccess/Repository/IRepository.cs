using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerWithWebApi.DataAccess.Repository
{
    public interface IRepository<T> : IRepository where T : class, new()
    {
        T Add(T entity);
        void Remove(T entity);
        void Remove(int id);
        T Update(T entity);
        IEnumerable<T> Get();
        T Get(int id);
        Task<T> GetAsync(int Id);

        //IEnumerable<T> GetAll();
        //Task<T> GetByIdAsync(int Id);
        //T Insert(T obj);
        //void Update(T obj);
        //void Delete(T entity);
    }

    public interface IRepository
    {

    }
}
