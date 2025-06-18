using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Firestore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InnatAPP.Infra.Data.Jobs
{
    public class ReviewSyncJob : BackgroundService
    {
        private readonly FirestoreService _firestoreService;
        private readonly IReviewRepository _reviewRepository;
        private readonly ILogger<ReviewSyncJob> _logger;

        public ReviewSyncJob(
            FirestoreService firestoreService,
            IReviewRepository reviewRepository,
            ILogger<ReviewSyncJob> logger)
        {
            _firestoreService = firestoreService;
            _reviewRepository = reviewRepository;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("ReviewSyncJob iniciado.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var documentos = await _firestoreService.ObterDocumentosAsync("reviews");

                    foreach (var doc in documentos)
                    {
                        var id = Guid.Parse(doc.GetValue<string>("id"));
                        var nota = doc.GetValue<decimal>("nota");
                        var resenha = doc.GetValue<string>("resenha");
                        var criadoEm = doc.GetValue<DateTime>("criadoEm");
                        var atualizadoEm = doc.GetValue<DateTime>("atualizadoEm");
                        var curtidas = doc.ContainsField("curtidas") ? doc.GetValue<int>("curtidas") : 0;
                        var descurtidas = doc.ContainsField("descurtidas") ? doc.GetValue<int>("descurtidas") : 0;
                        var idAvaliador = Guid.Parse(doc.GetValue<string>("idAvaliador"));
                        var idProduto = Guid.Parse(doc.GetValue<string>("idProduto"));

                        var existente = await _reviewRepository.BuscarReviewPorIdAsync(id);

                        if (existente == null)
                        {
                            var review = new Review(id, nota, resenha, criadoEm, atualizadoEm, curtidas, descurtidas, idAvaliador, idProduto);
                            await _reviewRepository.CriarReviewAsync(review);
                            _logger.LogInformation("Review criada: {Id}", id);
                        }
                        else
                        {
                            _logger.LogInformation("Review já existente: {Id}", id);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao sincronizar reviews.");
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
