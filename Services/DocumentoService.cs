public class DocumentoService
{
  public ResultadoValidacaoDocumento ValidarDocumento(Documento documento)
  {
    // Simulação: valida sempre como válido se nome não for vazio
    var valido = !string.IsNullOrWhiteSpace(documento.Nome);

    return new ResultadoValidacaoDocumento
    {
      DocumentoValido = valido,
      MotivoInvalidez = valido ? "" : "Nome inválido ou ausente.",
      DataProcessamento = DateTime.UtcNow
    };
  }
}
