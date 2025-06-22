using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.CQRS.Usuarios.Commands;
using InnatAPP.Application.CQRS.Avaliadores.Commands;
using InnatAPP.Application.CQRS.Empresas.Commands;

namespace InnatAPP.Application.CQRS.Usuarios.Handlers
{
    public class UsuarioRemoveCommandHandler : IRequestHandler<UsuarioRemoveCommand, Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioRemoveCommandHandler(
            IUsuarioRepository usuarioRepository,
            IMediator mediator,
            IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        public async Task<Usuario> Handle(UsuarioRemoveCommand request, CancellationToken cancellationToken)
        {
            // Busca o usuário
            var usuario = await _usuarioRepository.BuscarUsuarioPorIdAsync(request.Id) ?? throw new ApplicationException("Usuário não encontrado.");

            // Deleta empresa ou avaliador conforme o tipo de usuário
            if (usuario.TipoUsuario.Valor == "Empresa")
            {
                await _mediator.Send(new EmpresaRemoveByUsuarioIdCommand(usuario.Id), cancellationToken);
            }
            else if (usuario.TipoUsuario.Valor == "Avaliador")
            {
                await _mediator.Send(new AvaliadorRemoveByUsuarioIdCommand(usuario.Id), cancellationToken);
            }

            // Deleta o próprio usuário
            var resultado = await _usuarioRepository.DeletarUsuarioAsync(usuario);

            // Salva as mudanças
            await _unitOfWork.SalvarAsync(cancellationToken);

            return resultado;
        }
    }
}