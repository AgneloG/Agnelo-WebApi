using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SwaggerWithWebApi.DataAccess;
using SwaggerWithWebApi.DataAccess.Model;
using System.Transactions;

//using AngularWebApiSample.Models;

namespace SwaggerWithWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private SwaggerWithWebApi.DataAccess.Repository.IUnitOfWork db = new SwaggerWithWebApi.DataAccess.Repository.UnitOfWork();
        //private DBModels db = new DBModels();

        // GET: api/Employees
        /// <summary>
        /// Get all employees
        /// </summary>
        /// <remarks>Get a list of all employees that belong to the Webapi db</remarks>
        /// <returns>List of Employees</returns>
        public IEnumerable<Employee> GetEmployees()
        {
            return db.EmployeeRepo.Get();
        }

        // GET: api/Employees/5
        /// <summary>
        /// Retrieve employee
        /// </summary>
        /// <returns>List of Employees</returns>
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> GetEmployee(int id)
        {
            Employee employee = await db.EmployeeRepo.GetAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        // GET: api/Employees/5
        /// <summary>
        /// Update employee
        /// </summary>
        /// <returns>List of Employees</returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeID)
            {
                return BadRequest();
            }

            //db.Entry(employee).State = EntityState.Modified;

            try
            {
                using (var transaction = new TransactionScope())
                {
                    db.EmployeeRepo.Update(employee);

                    transaction.Complete();
                }
                //await db.CompleteAsync();
            }
            catch (DataException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        // GET: api/Employees/5
        /// <summary>
        /// Insert new employee
        /// </summary>
        /// <returns>List of Employees</returns>
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> PostEmployee(Employee employee)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.EmployeeRepo.Add(employee);
            //var result = await db.CompleteAsync();
            //await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeID }, employee);
        }

        // DELETE: api/Employees/5
        // GET: api/Employees/5
        /// <summary>
        /// Delete existing employee
        /// </summary>
        /// <returns>List of Employees</returns>
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> DeleteEmployee(int id)
        {
            Employee employee = await db.EmployeeRepo.GetAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.EmployeeRepo.Remove(employee);
            //var result = await db.CompleteAsync();

            return Ok(employee);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool EmployeeExists(int id)
        {
            return db.EmployeeRepo.EmployeeCount(id).Result > 0;
        }
    }
}