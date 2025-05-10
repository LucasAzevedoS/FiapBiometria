public class ResultadoValidacaoDocumento
{
  public required bool DocumentoValido { get; set; }
  public required string MotivoInvalidez { get; set; }
  public required DateTime DataProcessamento { get; set; }
}
