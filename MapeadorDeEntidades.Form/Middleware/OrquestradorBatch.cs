using System;
using MapeadorDeEntidades.Form.Core;
using System.Windows.Forms;
using MapeadorDeEntidades.Form.Core.SGBD.Oracle.Batch;
using MapeadorDeEntidades.Form.Core.SGBD.Oracle.Sequence;
using MapeadorDeEntidades.Form.Utilidade;

namespace MapeadorDeEntidades.Form.Middleware
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
            var dataFinal = DateTime.Now;
            Util.Status($"Tempo de processamento: {(dataFinal - dataInicial).Seconds}s - Tabelas: {ParamtersInput.NomeTabelas.Count}");
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
                        return new RequestMessage<string>();
                    }
                default:
                    {
                        return new RequestMessage<string>();
                    }
            }
        }
    }
}
