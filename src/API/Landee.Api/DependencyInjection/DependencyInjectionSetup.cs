namespace Landee.Api.DependencyInjection;

public static class DependencyInjectionSetup
{
    public static WebApplicationBuilder ConfigureDependencyInjection(this WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder
            .Services
            .AddConfiguration()
            .AddControllers()
            .Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();

        return webApplicationBuilder;
    }
}
