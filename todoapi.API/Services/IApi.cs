namespace todoapi.API.Services;

public interface IApi
{
    IServiceCollection RegisterServices(IServiceCollection builder);
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}

public static class ModuleExtensions
{
    // this could also be added into the DI container
    static readonly List<IApi> registeredModules = new List<IApi>();

    public static IServiceCollection RegisterModules(this IServiceCollection services)
    {
        var modules = DiscoverApis();
        foreach (var module in modules)
        {
            module.RegisterServices(services);
            registeredModules.Add(module);
        }

        return services;
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        foreach (var module in registeredModules)
        {
            module.MapEndpoints(app);
        }
        return app;
    }

    private static IEnumerable<IApi> DiscoverApis()
    {
        return typeof(IApi).Assembly
            .GetTypes()
            .Where(p => p.IsClass && p.IsAssignableTo(typeof(IApi)))
            .Select(Activator.CreateInstance)
            .Cast<IApi>();
    }
}
