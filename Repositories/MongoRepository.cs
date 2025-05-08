using BiometriaValidacaoApi.Models;
using MongoDB.Driver;

namespace BiometriaValidacaoApi
{
    public class MongoRepository : IMongoRepository
    {
        private readonly IMongoCollection<ResultadoValidacao> _collection;

        public MongoRepository(IConfiguration config)
        {
            var client = new MongoClient(config["MongoSettings:ConnectionString"]);
            var database = client.GetDatabase(config["MongoSettings:Database"]);
            _collection = database.GetCollection<ResultadoValidacao>("registros_validacao");
        }

        public async Task SalvarRegistroAsync(ResultadoValidacao resultado)
        {
            await _collection.InsertOneAsync(resultado);
        }
    }
}
