using FluentValidation;

namespace ToDoApp.Application.ToDo.Commands.CreateToDo
{
    public class CreateToDoValidator : AbstractValidator<CreateToDoCommand>
    {
        public CreateToDoValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
            RuleFor(x => x.Username).NotNull();
        }
    }
}
