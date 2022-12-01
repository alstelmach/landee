namespace Landee.Api.Web;

public static class WebApplicationSetup
{
    public static WebApplication ConfigureWebApplication(this WebApplication webApplication)
    {
        webApplication
            .ConfigureSwagger()
            .MapControllers();

        return webApplication;
    }

    private static WebApplication ConfigureSwagger(this WebApplication webApplication)
    {
        if (webApplication.Environment.IsDevelopment())
        {
            webApplication
                .UseSwagger()
                .UseSwaggerUI();
        }

        return webApplication;
    }
}
