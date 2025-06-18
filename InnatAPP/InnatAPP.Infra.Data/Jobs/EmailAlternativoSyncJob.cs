using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Firestore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InnatAPP.Infra.Data.Jobs
{
    public class EmailAlternativoSyncJob : BackgroundService
    {
        private readonly FirestoreService _firestoreService;
        private readonly IEmailAlternativoRepository _emailRepository;
        private readonly ILogger<EmailAlternativoSyncJob> _logger;

        public EmailAlternativoSyncJob(
            FirestoreService firestoreService,
            IEmailAlternativoRepository emailRepository,
            ILogger<EmailAlternativoSyncJob> logger)
        {
            _firestoreService = firestoreService;
            _emailRepository = emailRepository;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("EmailAlternativoSyncJob iniciado.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var documentos = await _firestoreService.ObterDocumentosAsync("emailsAlternativos");

                    foreach (var doc in documentos)
                    {
                        var id = Guid.Parse(doc.GetValue<string>("id"));
                        var enderecoEmail = doc.GetValue<string>("enderecoEmail");
                        var idUsuario = Guid.Parse(doc.GetValue<string>("idUsuario"));

                        var existente = await _emailRepository.BuscarEmailAlternativoPorIdAsync(id);

                        if (existente == null)
                        {
                            var novoEmail = new EmailAlternativo(id, enderecoEmail, idUsuario);
                            await _emailRepository.CriarEmailAlternativoAsync(novoEmail);
                            _logger.LogInformation("EmailAlternativo criado: {Id}", id);
                        }
                        else
                        {
                            // Atualização de campos se necessário
                            _logger.LogInformation("EmailAlternativo já existe: {Id}", id);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro na sincronização de emails alternativos.");
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
