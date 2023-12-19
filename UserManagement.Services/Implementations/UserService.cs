using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using UserManagement.Data.Data;
using UserManagement.Data.Models;
using UserManagement.Services.Contracts;
using UserManagement.Shared.Models.Input;
using UserManagement.Shared.Models.View;

namespace UserManagement.Services.Implementations;

internal class UserService : IUserServices
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public UserService(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task AddUserAsync(UserIM userIM)
    {
        var user = this.mapper.Map<User>(userIM);

        await this.context.Users.AddAsync(user);

        await this.context.SaveChangesAsync();
    }

    public async Task DeleteAllUsersAsync()
    {
        this.context.Users.RemoveRange(this.context.Users);

        await this.context.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserVM>> GetAllUsersAsync()
    {
        return await this.context
            .Users
            .ProjectTo<UserVM>(mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
