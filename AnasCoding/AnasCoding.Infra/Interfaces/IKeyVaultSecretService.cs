namespace AnasCoding.Infra.Interfaces
{
    public interface IKeyVaultSecretService
    {
        string RetornarSegredo(string chave);
    }
}