using NsiKlk1.Application.Users.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NsiKlk1.Api.Controllers;

public class UserController : ApiBaseController
{
    [Authorize]
    [HttpPost]
    public async Task<ActionResult> CreateUser(CreateUserCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}
