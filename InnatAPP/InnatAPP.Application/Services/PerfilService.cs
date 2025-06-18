using InnatAPP.Domain.Interfaces;

namespace InnatAPP.Application.Services
{
    public class PerfilService
    {
        private readonly IAvaliadorRepository _avaliadorRepo;
        private readonly IEmpresaRepository _empresaRepo;
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IUnitOfWork _uow;

        public PerfilService(
            IAvaliadorRepository avaliadorRepo,
            IEmpresaRepository empresaRepo,
            IUsuarioRepository usuarioRepo,
            IUnitOfWork uow)
        {
            _avaliadorRepo = avaliadorRepo;
            _empresaRepo = empresaRepo;
            _usuarioRepo = usuarioRepo;
            _uow = uow;
        }
    }
}