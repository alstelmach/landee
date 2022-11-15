using Landee.Api.DependencyInjection;
using Landee.Api.Web;

WebApplication
    .CreateBuilder(args)
    .ConfigureDependencyInjection()
    .Build()
    .ConfigureWebApplication()
    .Run();
