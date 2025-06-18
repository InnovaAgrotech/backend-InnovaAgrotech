using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Firestore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InnatAPP.Infra.Data.Jobs
{
    public class ProdutoSyncJob : BackgroundService
    {
        private readonly FirestoreService _firestoreService;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger<ProdutoSyncJob> _logger;

        public ProdutoSyncJob(
            FirestoreService firestoreService,
            IProdutoRepository produtoRepository,
            ILogger<ProdutoSyncJob> logger)
        {
            _firestoreService = firestoreService;
            _produtoRepository = produtoRepository;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("ProdutoSyncJob iniciado.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var documentos = await _firestoreService.ObterDocumentosAsync("produtos");

                    foreach (var doc in documentos)
                    {
                        var id = Guid.Parse(doc.GetValue<string>("id"));
                        var nome = doc.GetValue<string>("nome");
                        var descricao = doc.GetValue<string>("descricao");
                        var foto = doc.GetValue<string>("foto");
                        var nota = doc.ContainsField("nota") ? doc.GetValue<decimal>("nota") : 5.0m;
                        var totalReviews = doc.ContainsField("totalReviews") ? doc.GetValue<int>("totalReviews") : 0;
                        var idCategoria = Guid.Parse(doc.GetValue<string>("idCategoria"));
                        var idEmpresa = Guid.Parse(doc.GetValue<string>("idEmpresa"));

                        var existente = await _produtoRepository.BuscarProdutoPorIdAsync(id);

                        if (existente == null)
                        {
                            var produto = new Produto(id, nome, descricao, foto, nota, totalReviews, idCategoria, idEmpresa);
                            await _produtoRepository.CriarProdutoAsync(produto);
                            _logger.LogInformation("Produto criado: {Id}", id);
                        }
                        else
                        {
                            _logger.LogInformation("Produto já existente: {Id}", id);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao sincronizar produtos.");
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
