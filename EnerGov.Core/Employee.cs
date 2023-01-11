using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection.Metadata;
using System.Security.Principal;

namespace EnerGov.Core
{
    [Table("employee")]
    public class Employee : Person
    {
        [Key, Required]
        public int EmployeeId { get; set; }
        public Employee Manager { get; set; }
        public int? ManagerId { get; set; }

        public List<EmployeeRole> EmployeeRoles { get; set; }

    }
}