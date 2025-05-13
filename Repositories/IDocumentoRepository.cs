using BiometriaValidacaoApi.Models;
using System.Threading.Tasks;

namespace BiometriaValidacaoApi.Repositories
{
    public interface IDocumentoRepository
    {
        Task SalvarAsync(ResultadoValidacaoDocumento resultado);
    }
}
