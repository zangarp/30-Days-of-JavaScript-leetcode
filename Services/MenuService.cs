using FinOpsAPI.Interfaces;
using FinOpsAPI.Models;

namespace FinOpsAPI.Services
{
    public class MenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly ISDFORepository _sdfoRepository;
        
        public MenuService(
            IMenuRepository menuRepository,
            ISDFORepository sdfoRepository
            )
        {
            _menuRepository = menuRepository;
            _sdfoRepository = sdfoRepository;
        }

        public async Task<IEnumerable<Menu>> GetMenu(string connectionString)
        {
            var usersRolesGroup = await _sdfoRepository.GetUserGroupRole(connectionString);
            return await _menuRepository.GetMenu(connectionString, usersRolesGroup);
        }
    }
}
