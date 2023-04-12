using Microsoft.EntityFrameworkCore;
using WeeLink_API.Utils.Context;

namespace WeeLink_API.Utils.Extension;

public static class ContextDbExtension
{
    public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("ConnectionString");
        services.AddDbContext<ContextDb>(options => options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 32))));
    }
}
