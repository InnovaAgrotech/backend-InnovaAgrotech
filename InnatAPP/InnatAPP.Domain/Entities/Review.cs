using InnatAPP.Domain.Validation;

namespace InnatAPP.Domain.Entities
{
    public class Review
    {
        #region Propriedades

        public Guid Id { get; private set; }
        public decimal Nota { get; private set; }
        public string Resenha { get; private set; } = string.Empty;
        public DateTime CriadoEm { get; private set; }
        public DateTime AtualizadoEm { get; private set; }
        public int Curtidas { get; private set; }
        public int Descurtidas { get; private set; }


        #endregion

        #region Chaves Estrangeiras

        public Guid IdAvaliador { get; private set; }
        public Guid IdProduto { get; private set; }

        #endregion

        #region Propriedades de Navegação

        public Avaliador Avaliador { get; private set; } = default!;
        public Produto Produto { get; private set; } = default!;

        #endregion

        #region Construtores

        public Review() { }

        public Review(decimal nota, string resenha, Guid idAvaliador, Guid idProduto)
        {
            #region Validações de Entrada

            ValidateDomain(nota, resenha);

            #endregion

            #region Inicialização das Propriedades

            Id = Guid.NewGuid();
            CriadoEm = DateTime.UtcNow;
            AtualizadoEm = DateTime.UtcNow;
            Curtidas = 0;
            Descurtidas = 0;
            IdAvaliador = idAvaliador;
            IdProduto = idProduto;

            #endregion
        }

        public Review(Guid id, decimal nota, string resenha, DateTime criadoEm, DateTime atualizadoEm, int curtidas, int descurtidas, Guid idAvaliador, Guid idProduto)
        {
            #region Validações de Entrada

            DomainExceptionValidation.When(id == Guid.Empty, "O id é obrigatório.");

            ValidateDomain(nota, resenha);

            DomainExceptionValidation.When(curtidas < 0, "O número de curtidas não pode ser menor que zero (0).");

            DomainExceptionValidation.When(descurtidas < 0, "O número de descurtidas não pode ser menor que zero (0).");

            DomainExceptionValidation.When(idAvaliador == Guid.Empty, "O id de avaliador é obrigatório.");

            DomainExceptionValidation.When(idProduto == Guid.Empty, "O id de produto é obrigatório.");

            #endregion

            #region Inicialização das Propriedades


            Id = id;
            CriadoEm = criadoEm;
            AtualizadoEm = atualizadoEm;
            Curtidas = curtidas;
            Descurtidas = descurtidas;
            IdAvaliador = idAvaliador;
            IdProduto = idProduto;

            #endregion
        }

        #endregion

        #region Métodos Públicos

        public void Alterar(decimal nota, string resenha)
        {
            #region Validações de Entrada

            ValidateDomain(nota, resenha);

            #endregion

            #region Inicialização das Propriedades

            AtualizadoEm = DateTime.UtcNow;

            #endregion
        }

        #endregion

        #region Validações de Domínio

        private void ValidateDomain(decimal nota, string? resenha)
        {
            #region Validações de Nota

            DomainExceptionValidation.When(nota < 0, "A nota não pode ser menor que zero (0).");

            DomainExceptionValidation.When(nota > 5, "A nota não pode ser maior que cinco (5).");

            #endregion

            #region Validações de Resenha

            DomainExceptionValidation.When(!string.IsNullOrWhiteSpace(resenha) && resenha.Length < 5,
            "A resenha deve ter no mínimo 5 caracteres.");

            DomainExceptionValidation.When(resenha?.Length > 500,
            "A resenha pode ter no máximo 500 caracteres.");

            #endregion

            #region Inicialização das Propriedades

            Nota = nota;
            Resenha = resenha ?? string.Empty; ;

            #endregion
        }

        #endregion
    }
}