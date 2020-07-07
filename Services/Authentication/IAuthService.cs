
using System.Threading.Tasks;

namespace Services.Authentication
{
    public interface IAuthService
    {
        //Task<RegisterResult> RegisterAsync(RegisterModel registerModel);
        Task<LoginResult> LoginAsync(LoginModel loginModel);
        Task LogoutAsync();
    }
}