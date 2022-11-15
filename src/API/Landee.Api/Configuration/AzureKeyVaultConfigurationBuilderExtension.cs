using Azure.Identity;

namespace Landee.Api.Configuration;

public static class AzureKeyVaultConfigurationBuilderExtension
{
    public static IConfigurationBuilder AddVault(this IConfigurationBuilder configurationBuilder)
    {
        var keyVaultAddress = GetEnvironmentVariable(EnvironmentVariables.AzureKeyVaultUri);
        var keyVaultTenantId = GetEnvironmentVariable(EnvironmentVariables.AzureKeyVaultTenantId);
        var keyVaultClientId = GetEnvironmentVariable(EnvironmentVariables.AzureKeyVaultClientId);
        var keyVaultClientSecret = GetEnvironmentVariable(EnvironmentVariables.AzureKeyVaultClientSecret);

        var keyVaultUri = new Uri(keyVaultAddress);

        var clientSecretCredential = new ClientSecretCredential(
            keyVaultTenantId,
            keyVaultClientId,
            keyVaultClientSecret);

        configurationBuilder.AddAzureKeyVault(
            keyVaultUri,
            clientSecretCredential);

        return configurationBuilder;
    }

    private static string GetEnvironmentVariable(string variableName) =>
        Environment.GetEnvironmentVariable(variableName)
            ?? throw new ArgumentException("Environment variable is not defined", variableName);
}
