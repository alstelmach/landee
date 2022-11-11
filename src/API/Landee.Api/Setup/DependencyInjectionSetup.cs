namespace Landee.Api.Setup;

public static class DependencyInjectionSetup
{
    public static WebApplicationBuilder ConfigureDependencyInjection(this WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder
            .Services
            .AddControllers()
            .Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();

        return webApplicationBuilder;
    }
}
