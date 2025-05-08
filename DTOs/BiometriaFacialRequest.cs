using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BiometriaValidacaoApi
{
    public class BiometriaFacialRequest
    {
        [Required]
        public IFormFile Imagem { get; set; } = null!;

        [Required]
        public string Formato { get; set; } = null!;

        [Required]
        public double TamanhoKb { get; set; }

        public string? DataCaptura { get; set; }

        public string? FabricanteDispositivo { get; set; }

        public string? Localizacao { get; set; }
    }
}
