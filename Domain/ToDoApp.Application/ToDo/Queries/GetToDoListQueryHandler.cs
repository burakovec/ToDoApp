
using MediatR;

using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Enums;

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
            return toDoList.Where(x => x.Status != Status.Deleted).AsQueryable();
        }
    }
}
