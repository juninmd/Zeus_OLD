using System;
using System.Net;
using Zeus.Core;
using Zeus.Core.SGBD.Oracle.Sequence;
using Zeus.Utilidade;

namespace Zeus.Middleware
{
    public class OrquestradorSequences
    {
        public RequestMessage<string> Generate()
        {
            var dataInicial = DateTime.Now;
            var init = Init();
            var dataFinal = DateTime.Now;
            Util.Status(
                $"Tempo de processamento: {(dataFinal - dataInicial).Seconds}s - Tabelas: {ParamtersInput.NomeTabelas.Count}");
            return init;
        }

        public RequestMessage<string> Init()
        {
            switch (ParamtersInput.SGBD)
            {
                case 1:
                {
                    return new OracleOrquestradorSequence().Oracle();
                }
                default:
                    return new RequestMessage<string>
                    {
                        StatusCode = HttpStatusCode.InternalServerError,
                        Message = "Essa linguagem não possui sequence."
                    };
            }
        }
    }
}