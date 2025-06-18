using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Domain.ValueObjects;
using InnatAPP.Infra.Data.Firestore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InnatAPP.Infra.Data.Jobs
{
    public class UsuarioSyncJob : BackgroundService
    {
        private readonly FirestoreService _firestoreService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuarioSyncJob> _logger;

        public UsuarioSyncJob(
            FirestoreService firestoreService,
            IUsuarioRepository usuarioRepository,
            ILogger<UsuarioSyncJob> logger)
        {
            _firestoreService = firestoreService;
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("UsuarioSyncJob iniciado.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var documentos = await _firestoreService.ObterDocumentosAsync("usuarios");

                    foreach (var doc in documentos)
                    {
                        var id = Guid.Parse(doc.GetValue<string>("id"));
                        var nome = doc.GetValue<string>("nome");
                        var email = doc.GetValue<string>("email");
                        var senhaHash = doc.GetValue<string>("senhaHash");
                        var foto = doc.GetValue<string>("foto");
                        var biografia = doc.GetValue<string>("biografia");
                        var tipoUsuarioStr = doc.GetValue<string>("tipoUsuario");

                        TipoUsuario tipoUsuario = tipoUsuarioStr switch
                        {
                            "Empresa" => TipoUsuario.Empresa,
                            "Avaliador" => TipoUsuario.Avaliador,
                            "Administrador" => TipoUsuario.Administrador,
                            _ => throw new Exception($"TipoUsuario inválido: {tipoUsuarioStr}")
                        };

                        var existente = await _usuarioRepository.BuscarUsuarioPorIdAsync(id);

                        if (existente == null)
                        {
                            var usuario = new Usuario(id, nome, email, senhaHash, foto, biografia, tipoUsuario);
                            await _usuarioRepository.CriarUsuarioAsync(usuario);
                            _logger.LogInformation("Usuário criado: {Id}", id);
                        }
                        else
                        {
                            _logger.LogInformation("Usuário já existe: {Id}", id);
                            // Se quiser, pode atualizar propriedades aqui, se necessário.
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao sincronizar usuários.");
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
