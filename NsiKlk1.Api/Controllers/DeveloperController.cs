using NsiKlk1.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NsiKlk1.Application.Developers.Commands;
using NsiKlk1.Application.Developers.Queries;

namespace NsiKlk1.Api.Controllers;

public class DeveloperController(INsiKlk1DbContext dbContext) : ApiBaseController
{
    [HttpGet]
    public async Task<IActionResult> Details([FromQuery] DeveloperDetailsQuery query) => Ok(await Mediator.Send(query));

    [HttpPost]
    public async Task<IActionResult> Create(DeveloperCreateCommand command) => Ok(await Mediator.Send(command));
    
    [HttpDelete]
    public async Task<IActionResult> Delete(DeveloperDeleteCommand command) => Ok(await Mediator.Send(command));
}