using Microsoft.AspNetCore.Mvc;
using BiometriaValidacaoApi.Models;
using BiometriaValidacaoApi.Models.BiometriaValidacaoApi;

namespace BiometriaValidacaoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiometriaController : ControllerBase
    {
        private readonly IBiometriaService _biometriaService;

        public BiometriaController(IBiometriaService biometriaService)
        {
            _biometriaService = biometriaService;
        }

        // Método para validar a biometria facial
        [HttpPost("validar-facial")] // Definindo explicitamente o tipo HTTP (POST)
        public async Task<ActionResult<BiometriaFacial>> ValidarFacial(BiometriaFacialRequest request)
        {
            try
            {
                var resultado = await _biometriaService.ValidarFacialAsync(request);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao processar a biometria facial: {ex.Message}");
            }
        }
    }
}