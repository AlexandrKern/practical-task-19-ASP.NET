using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using practical_task_19_ASP.NET.Models;

namespace practical_task_19_ASP.NET.DataContext
{
    public class UserDbContext : IdentityDbContext<User>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
