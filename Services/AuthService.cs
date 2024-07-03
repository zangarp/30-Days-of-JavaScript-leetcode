using FinOpsAPI.Interfaces;
using FinOpsAPI.Models;

namespace FinOpsAPI.Services
{
    public class AuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<string> Login(Auth authModel)
        {
            return await _authRepository.Login(authModel);
        }
    }
}
