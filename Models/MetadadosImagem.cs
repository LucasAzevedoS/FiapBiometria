namespace BiometriaValidacaoApi.Models
{
    public class MetadadosImagem
    {
        public string? Formato { get; set; }
        public double TamanhoKb { get; set; }
        public string? DataCaptura { get; set; } 
        public string? FabricanteDispositivo { get; set; }
        public string? Localizacao { get; set; }
    }
}
