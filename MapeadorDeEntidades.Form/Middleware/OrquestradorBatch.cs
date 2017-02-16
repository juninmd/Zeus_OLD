using System;
using System.Windows.Forms;
using Zeus.Core;
using Zeus.Core.SGBD.Oracle.Batch;
using Zeus.Utilidade;

namespace Zeus.Middleware
{
    public class OrquestradorBatch
    {
        public RequestMessage<string> Generate(FolderBrowserDialog salvar)
        {
            var validate = salvar.ShowDialog();
            if (validate != DialogResult.OK)
                return new RequestMessage<string>()
                {
                    Message = "Processamento cancelado!",
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };

            var dataInicial = DateTime.Now;
            var init = Init(salvar);
            init.TechnicalMessage = ($"Tempo de processamento: {(DateTime.Now - dataInicial).Seconds}s - Tabelas: {ParamtersInput.NomeTabelas.Count}");
            return init;

        }
        public RequestMessage<string> Init(FolderBrowserDialog salvar)
        {
            switch (ParamtersInput.SGBD)
            {
                case 1:
                    {
                        return new OracleOrquestradorBatch().Oracle(salvar);
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
