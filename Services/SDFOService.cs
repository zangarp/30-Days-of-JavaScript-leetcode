using FinOpsAPI.Interfaces;
using FinOpsAPI.Models;
using FinOpsAPI.Models.Employee;
using Microsoft.Extensions.Caching.Memory;

namespace FinOpsAPI.Services
{
    public class SDFOService
    {
        private readonly ISDFORepository _repository;

        public SDFOService(
            ISDFORepository repository)
        {
            _repository = repository;
        }

        public async Task<double> GetUserRole(string connectionString)
        {
            return await _repository.GetUserGroupRole(connectionString);
        }

        public async Task<IEnumerable<Handbook>> GetHandbook(string connectionString, int handbookCode)
        {
            return await _repository.GetHandbook(connectionString, handbookCode);
        }

        public async Task<IEnumerable<Handbook>> GetHandbookWithVersion(string connectionString, int dataCode, Guid messageVersion)
        {
            return await _repository.GetHandbookWithVersion(connectionString, dataCode, messageVersion);
        }

        public async Task<IEnumerable<Field>> GetFields(string connectionString, Guid messageVersion)
        {
            return await _repository.GetFields(connectionString, messageVersion);
        }

        public async Task<Employee> GetEmployeeAsync(string connectionString, string userLogin)
        {
            return await _repository.GetEmployeeeAsync(connectionString, userLogin);
        }
    }
}
