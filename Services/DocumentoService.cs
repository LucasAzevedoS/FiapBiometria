using BiometriaValidacaoApi.Models;
using BiometriaValidacaoApi.Repositories;
using System;

namespace BiometriaValidacaoApi.Services
{
    public class DocumentoService
    {
        private readonly IDocumentoRepository _repo;

        public DocumentoService(IDocumentoRepository repo)
        {
            _repo = repo;
        }

        public async Task<ResultadoValidacaoDocumento> ValidarDocumentoAsync(Documento documento)
        {
            var valido = !string.IsNullOrWhiteSpace(documento.Nome);
            var resultado = new ResultadoValidacaoDocumento
            {
                DocumentoValido = valido,
                MotivoInvalidez = valido ? "" : "Nome inválido ou ausente.",
                DataProcessamento = DateTime.UtcNow
            };

            await _repo.SalvarAsync(resultado);
            return resultado;
        }
    }
}
