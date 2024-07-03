using FinOpsAPI.Models;
using FinOpsAPI.Models.Employee;
using FinOpsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace FinOpsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SDFOController : Controller
    {
        private readonly SDFOService _sdfoService;

        public SDFOController(SDFOService sdfoService)
        {
            _sdfoService = sdfoService;
        }

        [HttpGet("GetRolesGroup")]
        public async Task<double> GetUserRole()
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _sdfoService.GetUserRole(connectionString);
        }

        [HttpGet("GetHandbook")]
        public async Task<IEnumerable<Handbook>> GetHandbook(int handbookCode)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _sdfoService.GetHandbook(connectionString, handbookCode);
        }

        [HttpGet("GetHandbookWithVersion")]
        public async Task<IEnumerable<Handbook>> GetHandbookWithVersion(int dataCode, Guid messageVersion)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _sdfoService.GetHandbookWithVersion(connectionString, dataCode, messageVersion);
        }

        [HttpGet("GetFields")]
        public async Task<IEnumerable<Field>> GetFields(Guid messageVersion)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _sdfoService.GetFields(connectionString, messageVersion);
        }

        [HttpGet("GetEmployee")]
        public async Task<Employee> GetEmployeeAsync()
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            var userLogin = HttpContext.Items["UserLogin"] as string;
            return await _sdfoService.GetEmployeeAsync(connectionString, userLogin);
        }
    }
}
