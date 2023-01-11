using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EnerGov.Core
{
    public class EmployeeResponse : Person
    {
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }
    }
}
