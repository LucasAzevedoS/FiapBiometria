using BiometriaValidacaoApi;
using BiometriaValidacaoApi.Models;
using System.Threading.Tasks;

namespace BiometriaValidacaoAPI
{
    public class FakeMongoRepository : IMongoRepository
    {
        public Task SalvarRegistroAsync(ResultadoValidacao resultado)
        {
            Console.WriteLine("Simulando salvamento no banco de dados:");
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(resultado));
            return Task.CompletedTask;
        }
    }
}
