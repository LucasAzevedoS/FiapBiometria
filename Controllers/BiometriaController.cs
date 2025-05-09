using Microsoft.AspNetCore.Mvc;
using BiometriaValidacaoApi.Models;
using BiometriaValidacaoApi.DTOs;
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

        // Endpoint para validação facial
        [HttpPost("validar-facial")]
        public async Task<ActionResult<BiometriaFacial>> ValidarFacial([FromForm] BiometriaFacialRequest request)
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

        // Endpoint para validação digital
        [HttpPost("validar-digital")]
        public async Task<ActionResult<BiometriaDigital>> ValidarDigital([FromForm] BiometriaDigitalRequest request)
        {
            try
            {
                var resultado = await _biometriaService.ValidarDigitalAsync(request);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao processar a biometria digital: {ex.Message}");
            }
        }
    }
}
