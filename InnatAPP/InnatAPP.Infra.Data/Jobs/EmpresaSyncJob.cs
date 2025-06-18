using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Firestore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InnatAPP.Infra.Data.Jobs
{
    public class EmpresaSyncJob : BackgroundService
    {
        private readonly FirestoreService _firestoreService;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly ILogger<EmpresaSyncJob> _logger;

        public EmpresaSyncJob(
            FirestoreService firestoreService,
            IEmpresaRepository empresaRepository,
            ILogger<EmpresaSyncJob> logger)
        {
            _firestoreService = firestoreService;
            _empresaRepository = empresaRepository;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("EmpresaSyncJob iniciado.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var documentos = await _firestoreService.ObterDocumentosAsync("empresas");

                    foreach (var doc in documentos)
                    {
                        var id = Guid.Parse(doc.GetValue<string>("id"));
                        var idUsuario = Guid.Parse(doc.GetValue<string>("idUsuario"));

                        var empresaExistente = await _empresaRepository.BuscarEmpresaPorIdAsync(id);

                        if (empresaExistente == null)
                        {
                            var novaEmpresa = new Empresa(id, idUsuario); // <-- construtor direto
                            await _empresaRepository.CriarEmpresaAsync(novaEmpresa);
                            _logger.LogInformation("Empresa criada: {Id}", id);
                        }
                        else
                        {
                            // Pode adicionar atualização se houver campos relevantes
                            _logger.LogInformation("Empresa já existe: {Id}", id);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao sincronizar empresas.");
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
