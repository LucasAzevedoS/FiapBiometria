
using BiometriaValidacaoApi.Models;
using BiometriaValidacaoApi.Models.BiometriaValidacaoApi;


namespace BiometriaValidacaoApi
{
    public interface IBiometriaService
    {
        Task<BiometriaFacial> ValidarFacialAsync(BiometriaFacialRequest request);
    }
}
