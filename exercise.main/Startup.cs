using Microsoft.Extensions.DependencyInjection;

namespace exercise.main;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IInventory, Inventory>();
    }
}