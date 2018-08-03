using DataAccess.Models;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace SwaggerWithWebApi.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        
        public IEmployeeRepository EmployeeRepo { get; private set; }

        public UnitOfWork()
        {
            EmployeeRepo = new RepositoryFactory().GetDataRepository<EmployeeRepository>();
        }



        //private IEmployeeRepository employeeRepository { get; set; }

        //public DBModels Context { get; set; }

        //public UnitOfWork()
        //{
        //    Context = new DBModels();
        //}

        //public IEmployeeRepository EmployeeRepository
        //{
        //    get
        //    {
        //        if(employeeRepository == null)
        //            employeeRepository = new EmployeeRepository(Context);
        //        return employeeRepository;
        //    }
        //}

        //public Task<int> CompleteAsync()
        //{
        //    try
        //    {
        //        return Context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        throw;
        //    }

        //}

        //public void Dispose()
        //{
        //    if (EmployeeRepo != null)
        //        EmployeeRepo.Dispose();
        //}
    }
}
