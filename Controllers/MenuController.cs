using FinOpsAPI.Models;
using FinOpsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinOpsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : Controller
    {
        private readonly MenuService _menuService;

        public MenuController(MenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("GetMenuList")]
        public async Task<IEnumerable<Menu>> GetMenu()
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _menuService.GetMenu(connectionString);
        }
    }
}
