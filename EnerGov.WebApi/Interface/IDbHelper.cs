using EnerGov.Core;

namespace EnerGov.WebApi.Interface
{
    public interface IDbHelper
    {
        public Task<List<EmployeeResponse>> GetAllManagers();
        public Task<List<EmployeeResponse>> GetAllByManagerID(int managerId);
        public Task<EmployeeResponse> SaveAccount(EmployeeRequest request);
    }
}
