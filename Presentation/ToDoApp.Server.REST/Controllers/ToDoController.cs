using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ToDoApp.Application.ToDo.Commands.CreateToDo;
using ToDoApp.Application.ToDo.Commands.DeleteToDo;
using ToDoApp.Application.ToDo.Commands.UpdateToDo;
using ToDoApp.Application.ToDo.Queries;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Server.REST.Controllers
{
    [Route("api/todo")]
    [ApiController]
    [Authorize]
    public class ToDoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToDoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet] 
        public async Task<IActionResult> GetToDoList(ODataQueryOptions<ToDoItem> queryOptions)
        {
            try
            {
                var result = await _mediator.Send(new GetToDoListQuery(User.Identity.Name, queryOptions));
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        } 

        [HttpPost]
        public async Task<IActionResult> CreateToDo(CreateToDoCommand command)
        {
            command.Username = User.Identity.Name;
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateToDo(UpdateToDoCommand command)
        {
            command.Username = User.Identity.Name;
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteToDo(string id)
        {
            var command = new DeleteToDoCommand(id, User.Identity.Name);
            await _mediator.Send(command);
            return Ok();
        }
    }
}