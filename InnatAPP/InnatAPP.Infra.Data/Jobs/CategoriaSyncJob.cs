using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Firestore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InnatAPP.Infra.Data.Jobs
{
    public class CategoriaSyncJob : BackgroundService
    {
        private readonly FirestoreService _firestoreService;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ILogger<CategoriaSyncJob> _logger;

        public CategoriaSyncJob(
            FirestoreService firestoreService,
            ICategoriaRepository categoriaRepository,
            ILogger<CategoriaSyncJob> logger)
        {
            _firestoreService = firestoreService;
            _categoriaRepository = categoriaRepository;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("CategoriaSyncJob iniciado.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var documentos = await _firestoreService.ObterDocumentosAsync("categorias");

                    foreach (var doc in documentos)
                    {
                        var id = Guid.Parse(doc.GetValue<string>("id"));
                        var nome = doc.GetValue<string>("nome");
                        // Ajuste para demais campos da Categoria

                        var categoriaExistente = await _categoriaRepository.BuscarCategoriaPorIdAsync(id);

                        var categoria = new Categoria
                        {
                            Id = id,
                            Nome = nome
                            // preencher outros campos
                        };

                        if (categoriaExistente == null)
                        {
                            await _categoriaRepository.CriarCategoriaAsync(categoria);
                            _logger.LogInformation("Categoria criada: {CategoriaId}", id);
                        }
                        else
                        {
                            // Atualiza campos desejados
                            categoriaExistente.Nome = nome;
                            // Outros campos

                            await _categoriaRepository.AtualizarCategoriaAsync(categoriaExistente);
                            _logger.LogInformation("Categoria atualizada: {CategoriaId}", id);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro no job de sincronização de categorias.");
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}


