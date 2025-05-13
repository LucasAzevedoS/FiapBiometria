public class DocumentoRequest
{
  public IFormFile ImagemDocumento { get; set; } 
  public string Nome { get; set; }
  public string NumeroDocumento { get; set; }
  public DateTime DataNascimento { get; set; }
}