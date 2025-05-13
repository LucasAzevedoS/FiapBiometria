using BiometriaValidacaoApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace BiometriaValidacaoApi.Repositories
{
    public class DocumentoRepository : IDocumentoRepository
    {
        private readonly IMongoCollection<ResultadoValidacaoDocumento> _colecao;

        public DocumentoRepository(IConfiguration config)
        {
            var connString = config["MongoSettings:ConnectionString"]
                             ?? throw new ArgumentException("MongoSettings:ConnectionString não configurado");
            var dbName = config["MongoSettings:Database"]
                             ?? throw new ArgumentException("MongoSettings:Database não configurado");

            var client = new MongoClient(connString);
            var database = client.GetDatabase(dbName);

            
            _colecao = database.GetCollection<ResultadoValidacaoDocumento>("registros_validacao_documento");
        }

        public async Task SalvarAsync(ResultadoValidacaoDocumento resultado)
        {
            await _colecao.InsertOneAsync(resultado);
        }
    }
}
