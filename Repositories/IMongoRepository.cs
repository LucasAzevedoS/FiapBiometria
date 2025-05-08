using BiometriaValidacaoApi.Models;

namespace BiometriaValidacaoApi
{
    public interface IMongoRepository
    {
        Task SalvarRegistroAsync(ResultadoValidacao resultado);
    }
}
