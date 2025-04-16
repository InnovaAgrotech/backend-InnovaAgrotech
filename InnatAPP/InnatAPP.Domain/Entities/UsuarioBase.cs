using System.Collections.Generic;

namespace InnatAPP.Domain.Entities
{
    public abstract class UsuarioBase
    {
        #region Atributos
        public int IdBase { get; set; }

        #endregion

        #region Coleções

        public ICollection<EmailAlternativo> EmailsAlternativos { get; set; } = new List<EmailAlternativo>();

        public ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();

        public ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();

        #endregion
    }
}
