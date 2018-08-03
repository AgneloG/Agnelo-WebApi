using SwaggerWithWebApi.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerWithWebApi.DataAccess.Repository
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        IList<Employee> GetEmployeesOrderByDesc();

        Task<int> EmployeeCount(int id);
    }
}
