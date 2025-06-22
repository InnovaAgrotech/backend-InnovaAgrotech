using MediatR;
using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Domain.ValueObjects;
using InnatAPP.Application.CQRS.Empresas.Commands;
using InnatAPP.Application.CQRS.Usuarios.Commands;
using InnatAPP.Application.CQRS.Avaliadores.Commands;

namespace InnatAPP.Application.CQRS.Usuarios.Handlers
{
    public class UsuarioCreateCommandHandler : IRequestHandler<UsuarioCreateCommand, Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IServicoHash _servicoHash;

        public UsuarioCreateCommandHandler(
            IUsuarioRepository usuarioRepository,
            IUnitOfWork unitOfWork,
            IMediator mediator,
            IServicoHash servicoHash)
        {
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _servicoHash = servicoHash;
        }

        public async Task<Usuario> Handle(UsuarioCreateCommand request, CancellationToken cancellationToken)
        {
            var tipoUsuario = TipoUsuario.FromString(request.TipoUsuarioTexto);

            var senhaHash = _servicoHash.GerarHash(request.SenhaHash);

            var usuario = new Usuario(
                request.Nome,
                request.Email,
                senhaHash,
                request.Foto,
                request.Biografia,
                tipoUsuario
            );

            await _usuarioRepository.CriarUsuarioAsync(usuario);

            // Criação automática da empresa ou avaliador
            if (tipoUsuario == TipoUsuario.Empresa)
            {
                await _mediator.Send(new EmpresaCreateCommand { IdUsuario = usuario.Id }, cancellationToken);
            }
            else if (tipoUsuario == TipoUsuario.Avaliador)
            {
                await _mediator.Send(new AvaliadorCreateCommand { IdUsuario = usuario.Id }, cancellationToken);
            }

            await _unitOfWork.SalvarAsync(cancellationToken);

            return usuario;
        }
    }
}