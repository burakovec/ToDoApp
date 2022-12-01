using MediatR;

namespace ToDoApp.Application.ToDo.Commands.DeleteToDo
{
    public class DeleteToDoCommand : IRequest
    {
        public DeleteToDoCommand(string id, string username)
        {
            Id = new Guid(id);
            Username = username;
        }

        public Guid Id { get; }

        public string Username { get; }
    }
}
