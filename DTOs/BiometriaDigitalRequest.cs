using Microsoft.AspNetCore.Http;
using System;

namespace BiometriaValidacaoApi.DTOs
{
    public class BiometriaDigitalRequest
    {
        public IFormFile ImagemDigital { get; set; } = null!;
        public string? Formato { get; set; }
        public double TamanhoKb { get; set; }
        public DateTime DataCaptura { get; set; }
        public string? FabricanteDispositivo { get; set; }
        public string? Localizacao { get; set; }
    }
}
