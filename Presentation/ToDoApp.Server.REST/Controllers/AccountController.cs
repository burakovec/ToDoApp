using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ToDoApp.Application.User.Commands;
using ToDoApp.Application.User.Queries;

namespace ToDoApp.Server.REST.Controllers
{
    [Route("api/account")]
    [Authorize]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login(GetTokenQuery getTokenQuery)
        {
            var result = await _mediator.Send(getTokenQuery);
            if (string.IsNullOrEmpty(result))
            {
                return Forbid();
            }

            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserCommand registerUserCommand)
        {
            var result = await _mediator.Send(registerUserCommand);

            if (!result.IsSuccessful)
            {
                Json(result.ErrorMessage);
            }

            return Ok();
        }

        [HttpGet]
        [Route("currentuser")]
        public IActionResult GetCurrentUser()
        {
            var currentUser = User.Identity.IsAuthenticated ? User.Identity.Name : null;
            return Json(currentUser);
        }
    }
}
