using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NsiKlk1.Api.Auth.Constants;
using NsiKlk1.Application.Games.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NsiKlk1.Application.Games.Queries;

namespace NsiKlk1.Api.Webhooks;

[Authorize(AuthenticationSchemes = nameof(AuthConstants.HeaderBasicAuthenticationScheme))]
public class GameWebhook : BaseWebhook
{
    [HttpGet]
    public async Task<IActionResult> Details([FromQuery] GameDetailsQuery query) => Ok(await Mediator.Send(query));
    
    [HttpPost]
    public async Task<IActionResult> Create(GameCreateCommand command) => Ok(await Mediator.Send(command));
    
    [HttpDelete]
    public async Task<IActionResult> Delete(GameDeleteCommand command) => Ok(await Mediator.Send(command));
}