
using ToDoApp.Domain.Generics;

namespace ToDoApp.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> Authenticate(string username, string password);

        Task<Result> RegisterUser(string email, string password);
    }
}
