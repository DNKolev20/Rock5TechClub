using Microsoft.EntityFrameworkCore;
using UserManagement.Data.Models;

namespace UserManagement.Data.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    { }

    public virtual DbSet<User> Users { get; set; }
}
