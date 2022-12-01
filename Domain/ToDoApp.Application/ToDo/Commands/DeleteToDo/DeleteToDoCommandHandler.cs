
using MediatR;

using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Enums;

namespace ToDoApp.Application.ToDo.Commands.DeleteToDo
{
    public class DeleteToDoCommandHandler : IRequestHandler<DeleteToDoCommand>
    {
        private readonly IToDoCommandRepository _commandRepository;
        private readonly IToDoQueryRepository _queryRepository;

        public DeleteToDoCommandHandler(IToDoCommandRepository commandRepository, IToDoQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<Unit> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {
            var toDo = await _queryRepository.GetToDo(request.Id, request.Username);
            toDo.SetStatus(Status.Deleted);

            await _commandRepository.UpdateToDo(toDo);

            return Unit.Value;
        }
    }
}
