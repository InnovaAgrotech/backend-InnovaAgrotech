using InnatAPP.Domain.Entities;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Firestore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InnatAPP.Infra.Data.Jobs
{
    public class EnderecoSyncJob : BackgroundService
    {
        private readonly FirestoreService _firestoreService;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly ILogger<EnderecoSyncJob> _logger;

        public EnderecoSyncJob(
            FirestoreService firestoreService,
            IEnderecoRepository enderecoRepository,
            ILogger<EnderecoSyncJob> logger)
        {
            _firestoreService = firestoreService;
            _enderecoRepository = enderecoRepository;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("EnderecoSyncJob iniciado.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var documentos = await _firestoreService.ObterDocumentosAsync("enderecos");

                    foreach (var doc in documentos)
                    {
                        var id = Guid.Parse(doc.GetValue<string>("id"));
                        var numero = doc.GetValue<string>("numero");
                        var rua = doc.GetValue<string>("rua");
                        var bairro = doc.GetValue<string>("bairro");
                        var cidade = doc.GetValue<string>("cidade");
                        var estado = doc.GetValue<string>("estado");
                        var complemento = doc.GetValue<string>("complemento");
                        var cep = doc.GetValue<string>("cep");
                        var idUsuario = Guid.Parse(doc.GetValue<string>("idUsuario"));

                        var existente = await _enderecoRepository.BuscarEnderecoPorIdAsync(id);

                        if (existente == null)
                        {
                            var novoEndereco = new Endereco(id, numero, rua, bairro, cidade, estado, complemento, cep, idUsuario);
                            await _enderecoRepository.CriarEnderecoAsync(novoEndereco);
                            _logger.LogInformation("Endereco criado: {Id}", id);
                        }
                        else
                        {
                            // Atualizações podem ser implementadas aqui, se necessário
                            _logger.LogInformation("Endereco já existente: {Id}", id);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao sincronizar endereços.");
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
