using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Enderecos.Commands
{
    public abstract class EnderecoCommand : IRequest<Endereco>
    {
        public string Numero { get;  set; } = "S/N";
        public string Rua { get;  set; } = string.Empty;
        public string Bairro { get;  set; } = string.Empty;
        public string Cidade { get;  set; } = string.Empty;
        public string Estado { get;  set; } = string.Empty;
        public string Complemento { get;  set; } = string.Empty;
        public string Cep { get;  set; } = string.Empty;
        public Guid IdUsuario { get;  set; }
    }
}