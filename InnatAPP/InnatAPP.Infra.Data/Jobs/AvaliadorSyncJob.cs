using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Firestore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InnatAPP.Infra.Data.Jobs
{
    public class AvaliadorSyncJob : BackgroundService
    {
        private readonly FirestoreService _firestoreService;
        private readonly IAvaliadorRepository _avaliadorRepository;
        private readonly ILogger<AvaliadorSyncJob> _logger;

        public AvaliadorSyncJob(
            FirestoreService firestoreService,
            IAvaliadorRepository avaliadorRepository,
            ILogger<AvaliadorSyncJob> logger)
        {
            _firestoreService = firestoreService;
            _avaliadorRepository = avaliadorRepository;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("AvaliadorSyncJob iniciado.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var documentos = await _firestoreService.ObterDocumentosAsync("avaliadores");

                    foreach (var doc in documentos)
                    {
                        var id = Guid.Parse(doc.GetValue<string>("id"));
                        var idUsuario = Guid.Parse(doc.GetValue<string>("idUsuario"));

                        var avaliadorExistente = await _avaliadorRepository.BuscarAvaliadorPorIdAsync(id);

                        if (avaliadorExistente == null)
                        {
                            var novoAvaliador = new Avaliador(id, idUsuario); // <-- usando construtor

                            await _avaliadorRepository.CriarAvaliadorAsync(novoAvaliador);
                            _logger.LogInformation("Avaliador criado: {Id}", id);
                        }
                        else
                        {
                            // Atualização simples, se houver campos a atualizar
                            // Neste exemplo não há campos extras, apenas log
                            _logger.LogInformation("Avaliador já existe: {Id}", id);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao sincronizar avaliadores.");
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
