using BiometriaValidacaoApi.Repositories;
using BiometriaValidacaoApi.Services;
using BiometriaValidacaoApi.DTOs;
using BiometriaValidacaoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiometriaValidacaoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentoController : ControllerBase
    {
        private readonly DocumentoService _documentoService;

        
        public DocumentoController(DocumentoService documentoService)
        {
            _documentoService = documentoService;
        }

        [HttpPost("validar-documento")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> ValidarDocumento([FromForm] DocumentoRequest request)
        {
            if (request.ImagemDocumento == null || request.ImagemDocumento.Length == 0)
                return BadRequest("Imagem do documento é obrigatória.");

            
            using var ms = new MemoryStream();
            await request.ImagemDocumento.CopyToAsync(ms);
            var imagemBytes = ms.ToArray();
            var imagemBase64 = Convert.ToBase64String(imagemBytes);

            var documento = new Documento
            {
                Nome = request.Nome,
                NumeroDocumento = request.NumeroDocumento,
                DataNascimento = request.DataNascimento,
                ImagemBase64 = imagemBase64
            };

            
            var resultado = await _documentoService.ValidarDocumentoAsync(documento);

            return Ok(resultado);
        }
    }
}
