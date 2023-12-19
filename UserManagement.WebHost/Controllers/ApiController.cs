using Microsoft.AspNetCore.Mvc;

namespace UserManagement.WebHost.Controllers;

[ApiController]
[Route("api")]
public class ApiController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return this.Ok("Hello from API!");
    }
}
