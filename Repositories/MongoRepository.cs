using BiometriaValidacaoApi.Models;
using MongoDB.Driver;

namespace BiometriaValidacaoApi.Repositories
{
    public class MongoRepository : IMongoRepository
    {
        private readonly IMongoDatabase _database;

        public MongoRepository(IConfiguration config)
        {
            var connectionString = config["MongoSettings:ConnectionString"];
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Configuração de MongoSettings:ConnectionString não encontrada.");

            var databaseName = config["MongoSettings:Database"];
            if (string.IsNullOrWhiteSpace(databaseName))
                throw new ArgumentException("Configuração de MongoSettings:Database não encontrada.");

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public async Task SalvarRegistroAsync<T>(T resultado, string? nomeColecao = null)
        {
            var nome = nomeColecao ?? typeof(T).Name; 
            var collection = _database.GetCollection<T>(nome.ToLowerInvariant()); 
            await collection.InsertOneAsync(resultado);
        }
    }
}