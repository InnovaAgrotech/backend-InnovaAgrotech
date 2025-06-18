using Google.Cloud.Firestore;
using Microsoft.Extensions.Configuration;

namespace InnatAPP.Infra.Data.Firestore
{
    public class FirestoreService
    {
        private readonly FirestoreDb _firestoreDb;
        public FirestoreService(IConfiguration configuration)
        {
            var projectId = configuration["Firestore:ProjectId"];
            var keyFilePath = configuration["Firestore:KeyFilePath"];
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", keyFilePath);
            _firestoreDb = FirestoreDb.Create(projectId);
        }
        public FirestoreDb GetFirestoreDb() => _firestoreDb;

        public async Task<List<DocumentSnapshot>> ObterDocumentosAsync(string nomeColecao)
        {
            var colecao = _firestoreDb.Collection(nomeColecao);
            var snapshot = await colecao.GetSnapshotAsync();
            return snapshot.Documents.ToList();
        }
    }
}