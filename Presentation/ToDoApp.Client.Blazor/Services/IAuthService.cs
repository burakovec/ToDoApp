
using ToDoApp.Client.Blazor.ViewModels;

namespace ToDoApp.Client.Blazor.Services
{
    public interface IAuthService
    {
        Task<string> Login(LoginModel loginModel);

        Task Logout();

        Task<string> Register(RegisterModel registerModel);
    }
}
