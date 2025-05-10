using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DocumentoController : ControllerBase
{
  private readonly DocumentoService _documentoService;

  public DocumentoController()
  {
    _documentoService = new DocumentoService();
  }

  [HttpPost("validar-documento")]
  [Consumes("multipart/form-data")]
  public IActionResult ValidarDocumento([FromForm] DocumentoRequest request)
  {
    if (request.ImagemDocumento == null || request.ImagemDocumento.Length == 0)
    {
      return BadRequest("Imagem do documento é obrigatória.");
    }

    using var ms = new MemoryStream();
    request.ImagemDocumento.CopyTo(ms);
    var imagemBytes = ms.ToArray();
    var imagemBase64 = Convert.ToBase64String(imagemBytes);

    var documento = new Documento
    {
      Nome = request.Nome,
      NumeroDocumento = request.NumeroDocumento,
      DataNascimento = request.DataNascimento,
      ImagemBase64 = imagemBase64
    };

    var resultado = _documentoService.ValidarDocumento(documento);
    return Ok(resultado);
  }
}
