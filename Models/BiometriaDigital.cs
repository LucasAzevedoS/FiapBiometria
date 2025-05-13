using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace BiometriaValidacaoApi.Models
{
    public class BiometriaDigital : ResultadoValidacao
    {
        //[BsonId]

        //[BsonRepresentation(BsonType.ObjectId)]
        //public string? Id { get; set; }

        [BsonElement("tipoBiometria")]
        public string TipoBiometria { get; set; } 

        [BsonElement("imagemBase64")]
        public string ImagemBase64 { get; set; } = string.Empty;

        [BsonElement("metadados")]
        public MetadadosImagem Metadados { get; set; } = new MetadadosImagem();

        [BsonElement("validado")]
        public bool Validado { get; set; }

        [BsonElement("fraudeDetectada")]
        public bool FraudeDetectada { get; set; }

        [BsonElement("motivoFraude")]
        public string? MotivoFraude { get; set; }

        [BsonElement("dataProcessamento")]
        public DateTime DataProcessamento { get; set; } = DateTime.UtcNow;
    }
}
