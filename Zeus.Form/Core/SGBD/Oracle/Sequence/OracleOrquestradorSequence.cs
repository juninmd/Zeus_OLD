﻿using System;
using System.IO;
using System.Net;
using Zeus.Utilidade;

namespace Zeus.Core.SGBD.Oracle.Sequence
{
    public class OracleOrquestradorSequence
    {
        public RequestMessage<string> Oracle()
        {
            try
            {
                var max = ParamtersInput.NomeTabelas.Count;
                var i = 0;
                var local = ParamtersInput.SelectedPath;

                foreach (var nomeTabela in ParamtersInput.NomeTabelas)
                {
                    i++;
                    Util.Barra((int) ((decimal) i / max * 100));
                    Util.Status($"Processando tabela: {nomeTabela}");

                    var instancia = new OracleSequence().Init(nomeTabela);
                    File.WriteAllText(local + $"{nomeTabela}_SEQUENCE.sql", instancia);
                }

                return new RequestMessage<string>
                {
                    Message = "Processamento concluído com sucesso!",
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new RequestMessage<string>
                {
                    Message = "Falha no sistema!",
                    TechnicalMessage = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError,
                    StackTrace = ex.StackTrace
                };
            }
        }
    }
}