using FinOpsAPI.Models;
using FinOpsAPI.Models.Employee;

namespace FinOpsAPI.Interfaces
{
    public interface ISDFORepository
    {
        Task<double> GetUserGroupRole(string sdfoConnectionString);
        Task<IEnumerable<Handbook>> GetHandbook(string sdfoConnectionString, int handbookCode);
        Task<IEnumerable<Handbook>> GetHandbookWithVersion(string sdfoConnectionString, int dataCode, Guid messageVersion);
        Task<IEnumerable<Field>> GetFields(string sdfoConnectionString, Guid messageVersion);
        Task<Employee> GetEmployeeeAsync(string sdfoConnectionString, string userLogin);
    }
}
