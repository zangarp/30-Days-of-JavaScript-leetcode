using FinOpsAPI.Models;

namespace FinOpsAPI.Interfaces
{
    public interface IMenuRepository
    {
        Task<IEnumerable<Menu>> GetMenu(string connectionString, double usersRolesGroup);
    }
}
