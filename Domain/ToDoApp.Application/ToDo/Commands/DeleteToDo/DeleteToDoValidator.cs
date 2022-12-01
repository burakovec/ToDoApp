using FluentValidation;

namespace ToDoApp.Application.ToDo.Commands.DeleteToDo
{
    public class DeleteToDoValidator :AbstractValidator<DeleteToDoCommand>
    {
        public DeleteToDoValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Username).NotEmpty();
        }
    }
}
