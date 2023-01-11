using EnerGov.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace EnerGov.WebApi.EfCore
{
    public class EF_DataContext : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public EF_DataContext(DbContextOptions<EF_DataContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseSerialColumns();
            modelBuilder.Entity<EmployeeRole>()
                .HasOne(p => p.Employee)
                .WithMany(b => b.EmployeeRoles);
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, FirstName = "Jefferey", LastName = "Wells" },
                new Employee { EmployeeId = 2, FirstName = "Vector", LastName = "Atkins", ManagerId = 1},
                new Employee { EmployeeId = 3, FirstName = "Kelli", LastName = "Hamilton", ManagerId = 1 },
                new Employee { EmployeeId = 4, FirstName = "Adam", LastName = "Brown", ManagerId = 2 },
                new Employee { EmployeeId = 5, FirstName = "Lois", LastName = "Martinez", ManagerId = 3 },
                new Employee { EmployeeId = 6, FirstName = "Brian", LastName = "Cruz", ManagerId = 2 },
                new Employee { EmployeeId = 7, FirstName = "Michael", LastName = "Lind", ManagerId = 3 },
                new Employee { EmployeeId = 8, FirstName = "Kristen", LastName = "Floyd", ManagerId = 2 },
                new Employee { EmployeeId = 9, FirstName = "Eric", LastName = "Bay", ManagerId = 3 },
                new Employee { EmployeeId = 10, FirstName = "Brandon", LastName = "Young", ManagerId = 3 }
            );

            modelBuilder.Entity<EmployeeRole>().HasData(
                new EmployeeRole { EmployeeRoleId = 1, EmployeeId = 1, RoleId = (int)Roles.Director },
                new EmployeeRole { EmployeeRoleId = 2, EmployeeId = 2, RoleId = (int)Roles.Director },
                new EmployeeRole { EmployeeRoleId = 3, EmployeeId = 3, RoleId = (int)Roles.Director },
                new EmployeeRole { EmployeeRoleId = 4, EmployeeId = 4, RoleId = (int)Roles.IT },
                new EmployeeRole { EmployeeRoleId = 5, EmployeeId = 4, RoleId = (int)Roles.Support },
                new EmployeeRole { EmployeeRoleId = 6, EmployeeId = 5, RoleId = (int)Roles.Support },
                new EmployeeRole { EmployeeRoleId = 7, EmployeeId = 6, RoleId = (int)Roles.Accounting },
                new EmployeeRole { EmployeeRoleId = 8, EmployeeId = 7, RoleId = (int)Roles.Analyst },
                new EmployeeRole { EmployeeRoleId = 9, EmployeeId = 8, RoleId = (int)Roles.Analyst },
                new EmployeeRole { EmployeeRoleId = 10, EmployeeId = 8, RoleId = (int)Roles.Sales },
                new EmployeeRole { EmployeeRoleId = 11, EmployeeId = 9, RoleId = (int)Roles.IT },
                new EmployeeRole { EmployeeRoleId = 12, EmployeeId = 9, RoleId = (int)Roles.Sales },
                new EmployeeRole { EmployeeRoleId = 13, EmployeeId = 10, RoleId = (int)Roles.Accounting }
            );
        }

    }
}
