
using MediatR;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.ToDo.Queries
{
    public class GetToDoListQuery : IRequest<List<ToDoItem>>
    {
        public GetToDoListQuery(string username)
        {
            Username = username;
        }

        public string Username { get; private set; }
    }
}
