using System.ComponentModel.DataAnnotations;
using ToDoApp.Domain.Enums;

namespace ToDoApp.Domain.Entities
{
    public class ToDoItem
    {
        public ToDoItem(string description, string username)
            : this(Guid.NewGuid(), description, username)
        {
        }

        public ToDoItem(string description, Status status, DateTime createdDate, string id)
        {
            Status = status;
            SetDescription(description);
            CreatedDate = createdDate;
            Id = new Guid(id);
        }

        public ToDoItem(Guid id, string description, string username)
        {
            Id = id;
            CreatedDate = DateTime.UtcNow;
            Status = Status.ToDo;
            SetDescription(description);
            SetUsername(username);
        }

        // Private parameterless constructor is needed just for the serialization
        public ToDoItem()
        {
        }

        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public Status Status { get; set; }
        public string Username { get; set; }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException(nameof(description));
            }

            Description = description;
        }

        public void SetUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            Username = username;
        }

        public void SetStatus(Status status)
        {
            if (status == Status.None)
            {
                throw new ArgumentOutOfRangeException(nameof(status));
            }

            if (status == Status.Completed)
            {
                CompletedDate = DateTime.UtcNow;
            }

            Status = status;
        }
    }
}
