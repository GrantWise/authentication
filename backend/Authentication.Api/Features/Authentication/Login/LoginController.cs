using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Features.Authentication.Login;

[ApiController]
[Route("api/auth")]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
    {
        try
        {
            request.IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            request.DeviceInfo = HttpContext.Request.Headers.UserAgent.ToString();
            
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { message = "An error occurred during login" });
        }
    }
}