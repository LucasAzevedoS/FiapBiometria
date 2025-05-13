using BiometriaValidacaoApi.Models;

namespace BiometriaValidacaoApi
{
    public interface IMongoRepository
    {
        Task SalvarRegistroAsync<T>(T resultado, string? nomeColecao = null);
    }
}
