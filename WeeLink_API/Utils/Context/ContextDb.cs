using Microsoft.EntityFrameworkCore;
using WeeLink_Domain.Entities.User;

namespace WeeLink_API.Utils.Context;

public class ContextDb : DbContext
{
   
    public ContextDb(DbContextOptions<ContextDb> options) : base(options)
    {

    }

    public DbSet<User> User { get; set; }
}
