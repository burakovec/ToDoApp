using Grpc.Core;
using MediatR;
using ToDoApp.Application.ToDo.Queries;
using Google.Protobuf.WellKnownTypes;
using ToDoApp.Application.ToDo.Commands.CreateToDo;
using ToDoApp.Application.ToDo.Commands.DeleteToDo;
using ToDoApp.Application.ToDo.Commands.UpdateToDo;
using Microsoft.AspNetCore.Authorization;

namespace ToDoApp.Server.GRPC.Services
{

    [Authorize]
    public class ToDoService : ToDo.ToDoBase
    {
        private readonly IMediator _mediator;

        public ToDoService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task<GetToDoListReply> GetToDoList(GetToDoListRequest request, ServerCallContext context)
        {
            var result = await _mediator.Send(new GetToDoListQuery(request.Username));
            var response = new GetToDoListReply();
            foreach (var item in result)
            {
                response.ToDoList.Add(
                    new GetToDoListReply.Types.ToDoView
                        {
                            CreatedDate = Timestamp.FromDateTime(item.CreatedDate.ToUniversalTime()),
                            Description = item.Description,
                            Status = (int)item.Status,
                            Id = item.Id.ToString()
                        });
            }

            return response;
        }

        public override async Task<Empty> AddToDo(AddToDoRequest request, ServerCallContext context)
        {
            var command = new CreateToDoCommand(request.Id, request.Description,request.Username);
            await _mediator.Send(command);

            return new Empty();
        }

        public override async Task<Empty> UpdateToDo(UpdateToDoRequest request, ServerCallContext context)
        {
            var command = new UpdateToDoCommand(request.Id, request.Description, request.Status, request.Username);
            await _mediator.Send(command);
            return new Empty();
        }

        public override async Task<Empty> DeleteToDo(DeleteToDoRequest request, ServerCallContext context)
        {
            var command = new DeleteToDoCommand(request.Id, request.Username);
            await _mediator.Send(command);

            return new Empty();
        }
    }
}
