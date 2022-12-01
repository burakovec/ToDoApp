using MediatR;
using ToDoApp.Domain.Enums;

namespace ToDoApp.Application.ToDo.Events
{
    public class TaskUpdatedEvent : INotification
    {
        public string Email { get; }

        public string Description { get; }

        public Status Status { get; }

        public TaskUpdatedEvent(string email, string description, Status status)
        {
            Email = email;
            Description = description;
            Status = status;
        }
    }
}
