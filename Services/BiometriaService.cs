
using BiometriaValidacaoApi.Models;
using BiometriaValidacaoApi.Models.BiometriaValidacaoApi;
using BiometriaValidacaoApi.DTOs;
using System;
using System.IO;
using System.Threading.Tasks;
using NuGet.Protocol.Core.Types;

namespace BiometriaValidacaoApi
{
    public class BiometriaService : IBiometriaService
    {

        private readonly IMongoRepository _repository;

        public BiometriaService(IMongoRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultadoValidacao> ValidarDigitalAsync(BiometriaDigitalRequest request)
        {
            using var memoryStream = new MemoryStream();
            await request.ImagemDigital.CopyToAsync(memoryStream);
            var imagemBytes = memoryStream.ToArray();
            var imagemBase64 = Convert.ToBase64String(imagemBytes);

            var fraudeDetectada = imagemBytes.Length < 30000;
            var motivoFraude = fraudeDetectada ? "Imagem de digital muito pequena." : null;

            var resultado = new BiometriaDigital
            {
                ImagemBase64 = imagemBase64,
                Validado = !fraudeDetectada,
                FraudeDetectada = fraudeDetectada,
                MotivoFraude = motivoFraude,
                Metadados = new MetadadosImagem
                {
                    Formato = request.Formato,
                    TamanhoKb = request.TamanhoKb,
                    FabricanteDispositivo = request.FabricanteDispositivo,
                    Localizacao = request.Localizacao
                },
                DataProcessamento = DateTime.UtcNow
            };

            await _repository.SalvarRegistroAsync(resultado); 

            return resultado;
        }


        public async Task<BiometriaFacial> ValidarFacialAsync(BiometriaFacialRequest request)
        {
            using var memoryStream = new MemoryStream();
            await request.Imagem.CopyToAsync(memoryStream);
            var imagemBytes = memoryStream.ToArray();
            var imagemBase64 = Convert.ToBase64String(imagemBytes);

            var fraudeDetectada = imagemBytes.Length < 50000;
            var motivoFraude = fraudeDetectada ? "Imagem muito pequena para validação." : null;

            var biometria = new BiometriaFacial
            {
                ImagemBase64 = imagemBase64,
                Validado = !fraudeDetectada,
                FraudeDetectada = fraudeDetectada,
                MotivoFraude = motivoFraude,
                Metadados = new MetadadosImagem
                {
                    Formato = request.Formato,
                    TamanhoKb = request.TamanhoKb,
                    DataCaptura = request.DataCaptura,
                    FabricanteDispositivo = request.FabricanteDispositivo,
                    Localizacao = request.Localizacao
                },
                DataProcessamento = DateTime.UtcNow
            };

            await _repository.SalvarRegistroAsync(biometria); 

            return biometria;
        }

    }

}
