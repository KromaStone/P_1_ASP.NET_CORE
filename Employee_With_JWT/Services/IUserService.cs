using Employee_With_JWT.Identity;
using Employee_With_JWT.Models;

namespace Employee_With_JWT.Services
{
    public interface IUserService
    {

        Task<ApplicationUser> Authenticate(LoginViewModel loginViewModel);

    }
}
