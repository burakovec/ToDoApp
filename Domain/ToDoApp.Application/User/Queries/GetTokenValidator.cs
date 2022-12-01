using FluentValidation;

namespace ToDoApp.Application.User.Queries
{
    public class GetTokenValidator : AbstractValidator<GetTokenQuery>
    {
        public GetTokenValidator()
        {
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();
        }
    }
}