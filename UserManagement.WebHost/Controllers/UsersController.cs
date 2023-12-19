using Microsoft.AspNetCore.Mvc;
using UserManagement.Services.Contracts;
using UserManagement.Shared.Models.Input;
using UserManagement.Shared.Models.View;

namespace UserManagement.WebHost.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserServices userService;

    public UsersController(IUserServices userServices)
    {
        this.userService = userServices;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserVM>>> GetAllUsersAsync()
    {
        return this.Ok((await this.userService.GetAllUsersAsync()).Select(x => x.Username));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAllUsersAsync()
    {
        await this.userService.DeleteAllUsersAsync();

        return this.Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddUsersAsync()
    {
        var username = "Your username in lower case. Ex: ssivanov19";

        await this.userService.AddUserAsync(new UserIM { Username = "Dani" });
        await this.userService.AddUserAsync(new UserIM { Username = "Toni" });
        await this.userService.AddUserAsync(new UserIM { Username = "Krassi" });
        await this.userService.AddUserAsync(new UserIM { Username = "Anton" });
        await this.userService.AddUserAsync(new UserIM { Username = username });

        return this.Ok();
    }
}
