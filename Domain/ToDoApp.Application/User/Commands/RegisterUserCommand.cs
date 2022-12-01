using MediatR;
using ToDoApp.Domain.Generics;

namespace ToDoApp.Application.User.Commands
{
    public class RegisterUserCommand : IRequest<Result>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
