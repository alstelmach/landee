using Landee.Api.Setup;

WebApplication
    .CreateBuilder(args)
    .ConfigureDependencyInjection()
    .Build()
    .ConfigureWebApplication()
    .Run();
