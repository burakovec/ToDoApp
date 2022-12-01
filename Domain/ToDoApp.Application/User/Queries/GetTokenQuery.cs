using MediatR;

namespace ToDoApp.Application.User.Queries
{
    public class GetTokenQuery : IRequest<string>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
