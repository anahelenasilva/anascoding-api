using AnasCoding.Infra.Interfaces;
using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;

namespace AnasCoding.Infra.Services
{
    public class KeyVaultSecretService : IKeyVaultSecretService
    {
        public string RetornarSegredo(string chave)
        {
            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
                {
                    Delay= TimeSpan.FromSeconds(2),
                    MaxDelay = TimeSpan.FromSeconds(16),
                    MaxRetries = 5,
                    Mode = RetryMode.Exponential
                }
            };
            var client = new SecretClient(new Uri("https://anascoding-vault.vault.azure.net/"), new DefaultAzureCredential(), options);

            KeyVaultSecret senhaSecret = client.GetSecret(chave);
            return senhaSecret.Value;
        }
    }
}