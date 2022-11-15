namespace Landee.Api.Configuration;

public static class JsonFileConfigurationBuilderExtension
{
    public static IConfigurationBuilder AddJsonFiles(this IConfigurationBuilder configurationBuilder)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var configurationFileName = GetConfigurationFileName();

        configurationBuilder
            .SetBasePath(currentDirectory)
            .AddJsonFile(
                configurationFileName,
                false,
                true);

        return configurationBuilder;
    }

    private static string GetConfigurationFileName()
    {
        var environment = Environment
            .GetEnvironmentVariable(EnvironmentVariables.RuntimeEnvironment)
            ?? Environments.Development;

        var configurationFileName = $"Configuration/Source/appsettings.{environment}.json";

        return configurationFileName;
    }
}
