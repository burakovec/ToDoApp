
using MediatR;
using Microsoft.AspNetCore.OData.Query;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Generics;

namespace ToDoApp.Application.ToDo.Queries
{
    public class GetToDoListQuery : IRequest<Pagination>
    {
        public GetToDoListQuery(string username, ODataQueryOptions<ToDoItem> queryOptions)
        {
            Username = username;
            QueryOptions = queryOptions;
        }

        public string Username { get; private set; }
        public ODataQueryOptions<ToDoItem> QueryOptions { get; }
    }
}
