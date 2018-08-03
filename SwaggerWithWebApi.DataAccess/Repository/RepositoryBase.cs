using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerWithWebApi.DataAccess.Repository
{
    public abstract class RepositoryBase<T, U> : IRepository<T>//, IDisposable
        where T: class, new()
        where U: DbContext, new()
    {
        //protected DbContext Context { get; set; }

        //public Repository(DbContext context)
        //{
        //    Context = context;
        //}

        protected abstract T AddEntity(U entityContext, T entity);
        protected abstract T UpdateEntity(U entityContext, T entity);
        protected abstract IEnumerable<T> GetEntities(U entityContext);
        protected abstract T GetEntity(U entityContext, int id);
        protected abstract Task<T> GetEntityAsync(U entityContext, int id);

        public T Add(T entity)
        {
            using (U entityContext = new U())
            {
                T addedEntity = AddEntity(entityContext, entity);
                entityContext.SaveChanges();
                return addedEntity;
            }
        }

        public void Remove(T entity)
        {
            using (U entityContext = new U())
            {
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (U entityContext = new U())
            {
                T entity = GetEntity(entityContext, id);
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public T Update(T entity)
        {
            using (U entityContext = new U())
            {
                //T existingEntity = UpdateEntity(entityContext, entity);
                entityContext.Entry<T>(entity).State = EntityState.Modified;
                entityContext.SaveChanges();

                return entity;
            }
        }

        public IEnumerable<T> Get()
        {
            using (U entityContext = new U())
            {
                return (GetEntities(entityContext)).ToArray().ToList();
            }
        }

        public T Get(int id)
        {
            using (U entityContext = new U())
            {
                return GetEntity(entityContext, id);
            }
        }

        public async Task<T> GetAsync(int id)
        {
            using (U entityContext = new U())
            {
                return await GetEntityAsync(entityContext, id);
            }
        }



        //public void Delete(T entity)
        //{
        //    Context.Set<T>().Remove(entity);
        //}

        //public IEnumerable<T> GetAll()
        //{
        //    return Context.Set<T>().ToList();
        //}

        //public Task<T> GetByIdAsync(int Id)
        //{
        //     return Context.Set<T>().FindAsync(Id);
        //}

        //public T Insert(T obj)
        //{
        //    return Context.Set<T>().Add(obj);
        //}

        //public void Update(T obj)
        //{
        //    Context.Entry(obj).State = EntityState.Modified; //.Set<T>().Attach(obj);
        //}

        //public void Dispose()
        //{
        //    if(Context != null)
        //        Context.Dispose();
        //}
    }
}
