using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Firestore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InnatAPP.Infra.Data.Jobs
{
    public class TelefoneSyncJob : BackgroundService
    {
        private readonly FirestoreService _firestoreService;
        private readonly ITelefoneRepository _telefoneRepository;
        private readonly ILogger<TelefoneSyncJob> _logger;

        public TelefoneSyncJob(
            FirestoreService firestoreService,
            ITelefoneRepository telefoneRepository,
            ILogger<TelefoneSyncJob> logger)
        {
            _firestoreService = firestoreService;
            _telefoneRepository = telefoneRepository;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("TelefoneSyncJob iniciado.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var documentos = await _firestoreService.ObterDocumentosAsync("telefones");

                    foreach (var doc in documentos)
                    {
                        var id = Guid.Parse(doc.GetValue<string>("id"));
                        var ddd = doc.GetValue<string>("ddd");
                        var numero = doc.GetValue<string>("numero");
                        var idUsuario = Guid.Parse(doc.GetValue<string>("idUsuario"));

                        var existente = await _telefoneRepository.BuscarTelefonePorIdAsync(id);

                        if (existente == null)
                        {
                            var telefone = new Telefone(id, ddd, numero, idUsuario);
                            await _telefoneRepository.CriarTelefoneAsync(telefone);
                            _logger.LogInformation("Telefone criado: {Id}", id);
                        }
                        else
                        {
                            _logger.LogInformation("Telefone já existe: {Id}", id);
                            // Se quiser atualizar telefone existente, pode adicionar lógica aqui.
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao sincronizar telefones.");
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
