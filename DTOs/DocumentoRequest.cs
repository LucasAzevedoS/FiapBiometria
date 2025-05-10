public class DocumentoRequest
{
  public IFormFile ImagemDocumento { get; set; } // multipart/form-data
  public string Nome { get; set; }
  public string NumeroDocumento { get; set; }
  public DateTime DataNascimento { get; set; }
}