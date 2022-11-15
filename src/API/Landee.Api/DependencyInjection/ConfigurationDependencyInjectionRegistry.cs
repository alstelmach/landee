using Landee.Api.Configuration;

namespace Landee.Api.DependencyInjection;

public static class ConfigurationDependencyInjectionRegistry
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddJsonFiles()
            .AddVault()
            .Build();

        return services.RegisterConfiguration(configuration);
    }

    private static IServiceCollection RegisterConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var currentConfigurationDescriptor = services.First(descriptor =>
            descriptor.ServiceType == typeof(IConfiguration));

        services.Remove(currentConfigurationDescriptor);

        services.AddSingleton(configuration);

        return services;
    }
}
