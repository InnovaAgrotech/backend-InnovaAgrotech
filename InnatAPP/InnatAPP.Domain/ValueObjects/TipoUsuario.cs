using InnatAPP.Domain.Shared;

namespace InnatAPP.Domain.ValueObjects
{
    public sealed class TipoUsuario : ValueObject
    {
        public string Valor {  get; }

        public static readonly TipoUsuario Empresa = new ("Empresa");

        public static readonly TipoUsuario Avaliador = new ("Avaliador");

        public static readonly TipoUsuario Administrador = new ("Administrador");

        private TipoUsuario(string valor) 
        { 
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentNullException(nameof(valor), "Tipo de usuário não pode ser nulo ou vazio.");

            var valoresValidos = new[] { "Empresa", "Avaliador", "Administrador" };

            if (!valoresValidos.Contains(valor))
                throw new ArgumentException(
                    $"Tipo de usuário inválido, use \"Empresa\", \"Avaliador\" ou \"Administrador\".", nameof(valor));

            Valor = valor;
        }

        public static TipoUsuario FromString(string valor)
        {
            if (valor == null) throw new ArgumentNullException(nameof(valor));

            if (valor.Equals(Empresa.Valor, StringComparison.OrdinalIgnoreCase))
                return Empresa;

            if (valor.Equals(Avaliador.Valor, StringComparison.OrdinalIgnoreCase))
                return Avaliador;

            if (valor.Equals(Administrador.Valor, StringComparison.OrdinalIgnoreCase))
                return Administrador;

            throw new ArgumentException(
                $"Tipo de usuário inválido, use \"{Empresa.Valor}\", \"{Avaliador.Valor}\" ou \"{Administrador.Valor}\".", nameof(valor));
        }

        public override string ToString() => Valor;

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Valor;
        }

    }
}