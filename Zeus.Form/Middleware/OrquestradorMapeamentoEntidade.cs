using System;
using Zeus.Core;
using Zeus.Linguagens.Base;

namespace Zeus.Middleware
{
    public class OrquestradorMapeamentoEntidade
    {
        public RequestMessage<string> Generate()
        {
            var dataInicial = DateTime.Now;
            var init = new ChamadaEntidadesBase().Orquestrar(ParamtersInput.SelectedPath);
            init.TechnicalMessage =
                $"Tempo de processamento: {(DateTime.Now - dataInicial).Seconds}s - Tabelas: {ParamtersInput.NomeTabelas.Count}";
            return init;
        }
    }
}