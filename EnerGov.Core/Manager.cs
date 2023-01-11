using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EnerGov.Core
{
    public class Manager : Person
    {
        [Display(Name = "Manager ID")]
        [Key, Required]
        public int ManagerId { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
