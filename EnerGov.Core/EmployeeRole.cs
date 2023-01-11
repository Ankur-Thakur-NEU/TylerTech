using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnerGov.Core
{
    [Table("employeerole")]
    public class EmployeeRole
    {
        [Key, Required]
        public int EmployeeRoleId { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        public virtual int RoleId
        {
            get
            {
                return (int)this.Role;
            }
            set
            {
                Role = (Roles)value;
            }
        }
        [EnumDataType(typeof(Roles))]
        public Roles Role { get; set; }
    }
}
