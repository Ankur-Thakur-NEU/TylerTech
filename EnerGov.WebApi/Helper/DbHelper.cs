using EnerGov.Core;
using EnerGov.WebApi.EfCore;
using EnerGov.WebApi.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace EnerGov.WebApi.Helper
{
    public class DbHelper : IDbHelper
    {
        private EF_DataContext _context;

        public DbHelper(EF_DataContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeResponse>> GetAllManagers()
        {
            var managers = await _context.EmployeeRoles.Where(m => m.RoleId == (int)Roles.Director).Select(m => m.EmployeeId).Distinct().ToListAsync();
            var account = await _context.Employees.Where(m => managers.Contains(m.EmployeeId)).ToListAsync();
            List<EmployeeResponse> employees = new List<EmployeeResponse>();
            foreach (var employee in account)
            {
                employees.Add(new EmployeeResponse
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName
                });
            }
            return employees;
        }

        public async Task<List<EmployeeResponse>> GetAllByManagerID(int managerId)
        {
            var account = await _context.Employees.Where(m => m.ManagerId == managerId).ToListAsync();
            List<EmployeeResponse> employees = new List<EmployeeResponse>();
            foreach (var employee in account)
            {
                employees.Add(new EmployeeResponse
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName
                });
            }
            return employees;
        }

        public async Task<EmployeeResponse> SaveAccount(EmployeeRequest request)
        {
            try
            {
                var newEmployee = new Employee
                {
                    EmployeeId = request.EmployeeId,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    ManagerId = request.ManagerId
                };
                await _context.Employees.AddAsync(newEmployee);
                foreach (var role in request.Roles)
                {
                    await _context.EmployeeRoles.AddAsync(new EmployeeRole { EmployeeId = request.EmployeeId, RoleId = role });
                }
                await _context.SaveChangesAsync();
                return new EmployeeResponse
                {
                    EmployeeId = request.EmployeeId,
                    FirstName = request.FirstName,
                    LastName = request.LastName
                };
            }
            catch (Exception ex)
            {
                return new EmployeeResponse();
            }
        }
    }
}
