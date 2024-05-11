using NsiKlk1.Application.Auth.Commands.BeginLoginCommand;
using NsiKlk1.Application.Auth.Commands.CompleteLoginCommand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NsiKlk1.Api.Controllers;

public class AuthController : ApiBaseController
{
    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> BeginLogin(BeginLoginCommand command) => Ok(await Mediator.Send(command));

    [AllowAnonymous]
    [HttpGet("{validationToken}/CompleteLogin")]
    public async Task<ActionResult> CompleteLogin([FromRoute] string validationToken) => Ok(await Mediator.Send(new CompleteLoginCommand(validationToken)));
}
