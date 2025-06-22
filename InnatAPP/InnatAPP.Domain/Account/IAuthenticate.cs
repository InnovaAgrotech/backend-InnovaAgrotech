using InnatAPP.Domain.Entities;
using InnatAPP.Domain.ValueObjects;

namespace InnatAPP.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(string email, string password);
        Task<bool> UserExist(string email);
        public UserToken GetUserToken(Guid id, string email, TipoUsuario tipoUsuario);
    }
}