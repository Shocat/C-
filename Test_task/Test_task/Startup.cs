using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test_task.Models;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        string connectionString = Configuration.GetConnectionString("MyAppDbConnection");

        services.AddDbContext<MyAppDbContext>(options =>
            options.UseNpgsql(connectionString));

        // Другие настройки и сервисы вашего приложения
    }
}
