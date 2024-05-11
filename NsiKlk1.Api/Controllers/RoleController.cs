using NsiKlk1.Application.Roles.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NsiKlk1.Api.Controllers;

public class RoleController : ApiBaseController
{
    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> CreateRole(CreateRoleCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}
