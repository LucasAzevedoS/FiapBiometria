
using BiometriaValidacaoApi.Models;
using BiometriaValidacaoApi.Models.BiometriaValidacaoApi;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BiometriaValidacaoApi
{
    public class BiometriaService : IBiometriaService
    {
        public async Task<BiometriaFacial> ValidarFacialAsync(BiometriaFacialRequest request)
        {
            using var memoryStream = new MemoryStream();
            await request.Imagem.CopyToAsync(memoryStream);
            var imagemBytes = memoryStream.ToArray();
            var imagemBase64 = Convert.ToBase64String(imagemBytes);

            // Simulação de lógica de validação (substitua com IA ou heurística real depois)
            var fraudeDetectada = imagemBytes.Length < 50000; // Exemplo: fraude se muito pequeno
            var motivoFraude = fraudeDetectada ? "Imagem muito pequena para validação." : null;

            // Criação do objeto BiometriaFacial
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

            // Retorne diretamente o objeto BiometriaFacial
            return biometria;
        }
    }

}
