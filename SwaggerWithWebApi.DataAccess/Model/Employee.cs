namespace SwaggerWithWebApi.DataAccess.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //[Table("Employee")]
    public partial class Employee
    {
        /// <summary>
        /// Get Id of Employee
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// Employee First name
        /// </summary>
        [StringLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// Employee Last name
        /// </summary>
        [StringLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// Employee Code
        /// </summary>
        [StringLength(50)]
        public string EmpCode { get; set; }

        /// <summary>
        /// Employee Designation
        /// </summary>
        [StringLength(50)]
        public string Position { get; set; }

        /// <summary>
        /// Employee's Office name
        /// </summary>
        [StringLength(50)]
        public string Office { get; set; }
    }
}
