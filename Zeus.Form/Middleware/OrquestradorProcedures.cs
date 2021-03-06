﻿using System;
using Zeus.Core;
using Zeus.Linguagens.Base;
using Zeus.Utilidade;

namespace Zeus.Middleware
{
    public class OrquestradorProcedures
    {
        public RequestMessage<string> Generate()
        {
            var dataInicial = DateTime.Now;
            var init = new ChamadaProceduresBase().Orquestrar();
            var dataFinal = DateTime.Now;
            Util.Status(
                $"Tempo de processamento: {(dataFinal - dataInicial).Seconds}s - Tabelas: {ParamtersInput.NomeTabelas.Count}");
            return init;
        }
    }
}