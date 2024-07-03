using FinOpsAPI.Models;

namespace FinOpsAPI.Interfaces
{
    public interface IAuthRepository
    {
        Task<string> Login(Auth authModel);
    }
}
