using SwaggerWithWebApi.DataAccess.Model;
using System.Linq;
using System.Web.Http;

namespace AngularWebApiSample.Controllers
{
    public class ManagerController : ApiController
    {
        // GET: api/Employees
        /// <summary>
        /// Get list of managers
        /// </summary>
        /// <returns>List of Employees</returns>
        public IQueryable<Employee> GetManagers()
        {
            return null;
        }
    }
}