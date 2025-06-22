using MediatR;
using AutoMapper;
using InnatAPP.Domain.ValueObjects;
using InnatAPP.Application.Interfaces;
using InnatAPP.Application.CQRS.Usuarios.Queries;
using InnatAPP.Application.CQRS.Usuarios.Commands;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Application.DTOs.Usuario;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IServicoHash _servicoHash;

        public UsuarioService(IMapper mapper, IMediator mediator, IUsuarioRepository usuarioRepository, IServicoHash servicoHash)
        {
            _mapper = mapper;
            _mediator = mediator;
            _usuarioRepository = usuarioRepository;
            _servicoHash = servicoHash;
        }

        #region Buscas

        public async Task<UsuarioRespostaDTO?> BuscarUsuarioPorIdAsync(Guid id)
        {
            var usuarioByIdQuery = new GetUsuarioByIdQuery(id) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(usuarioByIdQuery);
            return _mapper.Map<UsuarioRespostaDTO>(resultado);
        }
        public async Task<UsuarioRespostaDTO?> BuscarUsuarioPorEmailAsync(string email)
        {
            var usuarioByEmailQuery = new GetUsuarioByEmailQuery(email) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(usuarioByEmailQuery);
            return _mapper.Map<UsuarioRespostaDTO>(resultado);
        }

        public async Task<UsuarioRespostaDTO?> BuscarUsuarioPorEmailESenhaAsync(LoginUsuarioDTO loginDto)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorEmailAsync(loginDto.Email);
            if (usuario == null || !_servicoHash.VerificarHash(loginDto.Senha, usuario.SenhaHash))
                return null;
            return _mapper.Map<UsuarioRespostaDTO>(usuario);
        }

        public async Task<IEnumerable<UsuarioRespostaDTO>> BuscarUsuariosAsync()
        {
            var usuariosQuery = new GetUsuariosQuery() ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(usuariosQuery);
            return _mapper.Map<IEnumerable<UsuarioRespostaDTO>>(resultado);
        }

        public async Task<IEnumerable<UsuarioRespostaDTO>> BuscarUsuariosPorTipoAsync(TipoUsuario tipoUsuario)
        {
            var usuariosByTipoQuery = new GetUsuariosByTipoQuery(tipoUsuario.Valor) ?? throw new Exception($"Não foi possível carregar a entidade.");
            var resultado = await _mediator.Send(usuariosByTipoQuery);
            return _mapper.Map<IEnumerable<UsuarioRespostaDTO>>(resultado);
        }

        #endregion

        #region Comandos

        public async Task<Usuario> CriarUsuarioAsync(UsuarioCreateDTO usuarioDto)
        {
            if (await _usuarioRepository.EmailJaExisteAsync(usuarioDto.Email))
                throw new ApplicationException("Este e-mail já está em uso.");

            if (await _usuarioRepository.NomeJaExisteAsync(usuarioDto.Nome))
                throw new ApplicationException("Este nome de usuário já está em uso.");

            var usuarioCreateCommand = _mapper.Map<UsuarioCreateCommand>(usuarioDto);

            var usuarioCriado = await _mediator.Send(usuarioCreateCommand);

            return usuarioCriado;
        }

        public async Task AtualizarUsuarioAsync(UsuarioUpdateDTO usuarioDto)
        {
            var usuarioUpdateCommand = _mapper.Map<UsuarioUpdateCommand>(usuarioDto);
            await _mediator.Send(usuarioUpdateCommand);
        }

        public async Task DeletarUsuarioAsync(Guid id)
        {
            var usuarioRemoveCommand = new UsuarioRemoveCommand(id) ?? throw new Exception($"Não foi possível carregar a entidade.");
            await _mediator.Send(usuarioRemoveCommand);
        }

        #endregion
    }
}