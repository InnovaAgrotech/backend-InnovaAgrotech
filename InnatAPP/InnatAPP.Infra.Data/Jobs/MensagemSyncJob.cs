using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Firestore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InnatAPP.Infra.Data.Jobs
{
    public class MensagemSyncJob : BackgroundService
    {
        private readonly FirestoreService _firestoreService;
        private readonly IMensagemRepository _mensagemRepository;
        private readonly ILogger<MensagemSyncJob> _logger;

        public MensagemSyncJob(
            FirestoreService firestoreService,
            IMensagemRepository mensagemRepository,
            ILogger<MensagemSyncJob> logger)
        {
            _firestoreService = firestoreService;
            _mensagemRepository = mensagemRepository;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("MensagemSyncJob iniciado.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var documentos = await _firestoreService.ObterDocumentosAsync("mensagens");

                    foreach (var doc in documentos)
                    {
                        var id = Guid.Parse(doc.GetValue<string>("id"));
                        var nome = doc.GetValue<string>("nome");
                        var email = doc.GetValue<string>("email");
                        var texto = doc.GetValue<string>("texto");

                        var existente = await _mensagemRepository.BuscarMensagemPorIdAsync(id);

                        if (existente == null)
                        {
                            var novaMensagem = new Mensagem(id, nome, email, texto);
                            await _mensagemRepository.CriarMensagemAsync(novaMensagem);
                            _logger.LogInformation("Mensagem criada: {Id}", id);
                        }
                        else
                        {
                            _logger.LogInformation("Mensagem já existente: {Id}", id);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao sincronizar mensagens.");
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
