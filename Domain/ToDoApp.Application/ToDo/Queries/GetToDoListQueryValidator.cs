using FluentValidation;

namespace ToDoApp.Application.ToDo.Queries
{
    public class GetToDoListQueryValidator : AbstractValidator<GetToDoListQuery>
    {
        public GetToDoListQueryValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
        }
    }
}

