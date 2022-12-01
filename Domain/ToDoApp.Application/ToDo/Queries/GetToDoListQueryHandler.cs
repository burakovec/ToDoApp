
using MediatR;

using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.ToDo.Queries
{
    public class GetTaskListQueryHandler : IRequestHandler<GetToDoListQuery, IQueryable<ToDoItem>>
    {
        private readonly IToDoQueryRepository _queryRepository;

        public GetTaskListQueryHandler(IToDoQueryRepository toDoRepository)
        {
            _queryRepository = toDoRepository;
        }

        public async Task<IQueryable<ToDoItem>> Handle(GetToDoListQuery request, CancellationToken cancellationToken)
        {
            var toDoList = await _queryRepository.GetToDoList(request.Username);
            var data = request.QueryOptions.ApplyTo(toDoList);
            return toDoList;
        }
    }
}
