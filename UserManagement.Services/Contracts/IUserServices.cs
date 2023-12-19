using UserManagement.Shared.Models.Input;
using UserManagement.Shared.Models.View;

namespace UserManagement.Services.Contracts;

public interface IUserServices
{
    Task DeleteAllUsersAsync();

    Task<IEnumerable<UserVM>> GetAllUsersAsync();

    Task AddUserAsync(UserIM userIM);
}
