
using MediatR;

using ToDoApp.Application.Interfaces;

namespace ToDoApp.Application.User.Queries
{
    public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery, string>
    {
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenService;

        public GetTokenQueryHandler(IIdentityService identityService, ITokenService tokenService)
        {
            _identityService = identityService;
            _tokenService = tokenService;
        }

        public async Task<string> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            string token = null;

            var isValid = await _identityService.Authenticate(request.Username, request.Password);
            if (isValid)
            {
                token = _tokenService.GenerateToken(request.Username);
            }

            return token;
        }
    }
}
