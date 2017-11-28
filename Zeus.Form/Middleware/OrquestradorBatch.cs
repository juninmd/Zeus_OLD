using System;
using Zeus.Core;
using Zeus.Core.SGBD.Oracle.Batch;

namespace Zeus.Middleware
{
    public class OrquestradorBatch
    {
        public RequestMessage<string> Generate()
        {
            var dataInicial = DateTime.Now;
            var init = Init();
            init.TechnicalMessage = ($"Tempo de processamento: {(DateTime.Now - dataInicial).Seconds}s - Tabelas: {ParamtersInput.NomeTabelas.Count}");
            return init;
        }

        public RequestMessage<string> Init()
        {
            switch (ParamtersInput.SGBD)
            {
                case 1:
                    {
                        return new OracleOrquestradorBatch().Oracle();
                    }
                case 2:
                    {
                        return new RequestMessage<string>()
                        {
                            Message = "Não foi desenvolvido para esse SGBD!",
                            StatusCode = System.Net.HttpStatusCode.BadRequest
                        };
                    }
                default:
                    {
                        return new RequestMessage<string>()
                        {
                            Message = "Não foi desenvolvido para esse SGBD!",
                            StatusCode = System.Net.HttpStatusCode.BadRequest
                        };
                    }
            }
        }
    }
}
