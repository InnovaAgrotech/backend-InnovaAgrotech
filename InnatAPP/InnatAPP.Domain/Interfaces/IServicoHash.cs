namespace InnatAPP.Domain.Interfaces
{
    public interface IServicoHash
    {
        string GerarHash(string senha);
        bool VerificarHash(string senhaTexto, string senhaHash);
    }
}