using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NsiKlk1.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ApiBaseController : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}