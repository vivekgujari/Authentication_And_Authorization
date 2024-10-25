using Authentication_And_Authorization.Models;

namespace Authentication_And_Authorization.Services.Interface
{
    public interface IAuthService
    {
        User? AddUser(User user);
        string Login(LoginRequest loginRequest);
    }
}
