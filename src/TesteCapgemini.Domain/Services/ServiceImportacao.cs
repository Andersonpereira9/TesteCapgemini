﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteCapgemini.Domain.Arguments;
using TesteCapgemini.Domain.Entities;
using TesteCapgemini.Domain.Extensions;
using TesteCapgemini.Domain.Interfaces.Repositories;
using TesteCapgemini.Domain.Interfaces.Services;

namespace TesteCapgemini.Domain.Services
{
    public class ServiceImportacao : IServiceImportacao
    {

        private readonly IRepositoryImportacao _repositoryImportacao;
        private readonly IMapper _mapper;

        public ServiceImportacao(IRepositoryImportacao repositoryImportacao,
                             IMapper mapper)
        {
            _repositoryImportacao = repositoryImportacao;
            _mapper = mapper;
        }

        public async Task<ImportacaoListaResponse> ImportarLista(IFormFile request)
        {

            var validaArquivo = request.VerificaArquivoExcel();

            if (validaArquivo.Result.Count() > 0)
                return new ImportacaoListaResponse(validaArquivo.Result);

            var lista = await request.Import();

            var validaImportacao = lista.ValidaImportacao();

            if (validaImportacao.Count() > 0)
                return new ImportacaoListaResponse(validaImportacao);

            var importacao = _mapper.Map<ImportacaoModel>(lista);

            return _mapper.Map<ImportacaoListaResponse>
                          (_repositoryImportacao.AdicionarImportacao(importacao));

        }

        public async Task<ImportacaoPorIdResponse> ObterImportacaoPorId(int id)
        {

            var importacao = await _repositoryImportacao.ObterImportacaoPorId(id);

            if (importacao == null)
                return new ImportacaoPorIdResponse ( "Importacão não encontrada", false );

            return _mapper.Map<ImportacaoPorIdResponse>(importacao);
        }

        public async Task<IEnumerable<ImportacaoListaResponse>> ObterImportacoes()
        {

            var lista = await _repositoryImportacao.ObterImportacoes();

            return _mapper.Map<IEnumerable<ImportacaoListaResponse>>(lista);
        }
    }
}
