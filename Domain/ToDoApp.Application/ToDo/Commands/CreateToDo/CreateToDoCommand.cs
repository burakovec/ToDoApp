using System.Text.Json.Serialization;
using MediatR;

namespace ToDoApp.Application.ToDo.Commands.CreateToDo
{
    public class CreateToDoCommand : IRequest
    {
        [JsonConstructor]
        public CreateToDoCommand()
        { 
        }

        public CreateToDoCommand(string id, string description, string username)
        {
            Id = new Guid(id);
            Description = description;
            Username = username;
        }

        public Guid Id { get; set; }

        public string Description { get; set; }

        public string Username { get; set; }
    }
}
