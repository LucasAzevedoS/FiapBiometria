namespace BiometriaValidacaoApi.Models
{
    public class ResultadoValidacao
    {
        //public string Id { get; set; }
        //public string UsuarioId { get; set; }
        public string Tipo { get; set; }
        public DateTime Data { get; set; } = DateTime.UtcNow;
        public bool FraudeDetectada { get; set; }
        public string Motivo { get; set; }
        public string NomeArquivo { get; set; }
        public long TamanhoBytes { get; set; }
    }
}
