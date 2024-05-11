using NsiKlk1.Application.Common.Interfaces;
using NsiKlk1.Application.Games.Commands;
using NsiKlk1.Application.Games.Queries;
using Microsoft.AspNetCore.Mvc;
using NsiKlk1.Application.Common.Dto.Game;
using NsiKlk1.Domain.Common.Extensions;

namespace NsiKlk1.Api.Controllers;

public class GameController(INsiKlk1DbContext dbContext) : ApiBaseController
{
    [HttpGet]
    public async Task<IActionResult> Details([FromQuery] GameDetailsQuery query) => Ok(await Mediator.Send(query));

    [HttpPost]
    public async Task<IActionResult> Create(GameCreateCommand command) => Ok(await Mediator.Send(command));
    
    [HttpDelete]
    public async Task<IActionResult> Delete(GameDeleteCommand command) => Ok(await Mediator.Send(command));
    
    [HttpPost("test-create")]
    public async Task<IActionResult> TestCreate(GameTestCreateDto dto)
    {
        var command = dto.Json.Deserialize<GameCreateCommand>(SerializerExtensions.SettingsWebOptions);
        
        return Ok(await Mediator.Send(command!));
    }
}