
using MediatR;

using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Generics;

namespace ToDoApp.Application.ToDo.Queries
{
    public class GetTaskListQueryHandler : IRequestHandler<GetToDoListQuery, Pagination>
    {
        private readonly IToDoQueryRepository _queryRepository;

        public GetTaskListQueryHandler(IToDoQueryRepository toDoRepository)
        {
            _queryRepository = toDoRepository;
        }

        public async Task<Pagination> Handle(GetToDoListQuery request, CancellationToken cancellationToken)
        {
            var toDoList = await _queryRepository.GetToDoList(request.Username); 
            var data = request.QueryOptions.ApplyTo(toDoList); 
            return new Pagination(data);
        }
    }
}
