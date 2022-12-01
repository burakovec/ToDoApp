
using MediatR;

using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Generics;

namespace ToDoApp.Application.User.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result>
    {
        private readonly IIdentityService _identityService;

        public RegisterUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.RegisterUser(request.Email, request.Password);

            return result;
        }
    }
}
