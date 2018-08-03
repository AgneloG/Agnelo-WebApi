using DataAccess.Models;
using SwaggerWithWebApi.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerWithWebApi.DataAccess.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee, DBModels>, IEmployeeRepository//Repository<Employee>, IEmployeeRepository
    {
        public Task<int> EmployeeCount(int id)
        {
            using (DBModels entityContext = new DBModels())
            {
                return entityContext.EmployeeSet.CountAsync(e => e.EmployeeID == id);
            }
        }

        public IList<Employee> GetEmployeesOrderByDesc()
        {
            using (DBModels entityContext = new DBModels())
            {
                return entityContext.EmployeeSet.OrderByDescending(x => x.EmployeeID).ToList();
            }
        }

        protected override Employee AddEntity(DBModels entityContext, Employee entity)
        {
            return entityContext.EmployeeSet.Add(entity);
        }

        protected override IEnumerable<Employee> GetEntities(DBModels entityContext)
        {
            return from e in entityContext.EmployeeSet
                   select e;
        }

        protected override Employee GetEntity(DBModels entityContext, int id)
        {
            var query = (from e in entityContext.EmployeeSet
                         where e.EmployeeID == id
                         select e);
            var result = query.FirstOrDefault();
            return result;
        }

        protected override Task<Employee> GetEntityAsync(DBModels entityContext, int id)
        {
            return entityContext.EmployeeSet.FindAsync(id);
        }

        protected override Employee UpdateEntity(DBModels entityContext, Employee entity)
        {
            return (from e in entityContext.EmployeeSet
                    where e.EmployeeID == entity.EmployeeID
                    select e).FirstOrDefault();
        }

        //public EmployeeRepository(DbContext context) : base(context)
        //{

        //}

        //IList<Employee> IEmployeeRepository.GetEmployeesOrderByDesc()
        //{
        //    return ModelContext.Employees.OrderByDescending(x => x.EmployeeID).ToList();
        //}

        //public Task<int> EmployeeCount(int id)
        //{
        //    return ModelContext.Employees.CountAsync(e => e.EmployeeID == id);
        //}

        //private DBModels ModelContext { get { return Context as DBModels; } }
    }
}
