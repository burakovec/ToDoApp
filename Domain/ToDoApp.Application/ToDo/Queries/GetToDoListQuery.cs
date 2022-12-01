
using MediatR;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.ToDo.Queries
{
    public class GetToDoListQuery : IRequest<IQueryable<ToDoItem>>
    {
        public GetToDoListQuery(string username)
        {
            Username = username;
        }

        public string Username { get; private set; }
    }
}
