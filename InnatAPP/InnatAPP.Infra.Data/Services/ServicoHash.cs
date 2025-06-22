using InnatAPP.Domain.Interfaces;

namespace InnatAPP.Infra.Data.Services
{
    public class ServicoHash : IServicoHash
    {
        public string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public bool VerificarHash(string senhaTexto, string senhaHash)
        {
            return BCrypt.Net.BCrypt.Verify(senhaTexto, senhaHash);
        }
    }
}