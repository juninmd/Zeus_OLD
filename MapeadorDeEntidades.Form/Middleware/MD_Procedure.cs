using MapeadorDeEntidades.Form.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapeadorDeEntidades.Form.Middleware
{
    public class MD_Procedure
    {
        private RequestMessage<string> Oracle(FolderBrowserDialog salvar)
        {
            try
            {
                var funcao = salvar.ShowDialog();
                if (funcao != DialogResult.OK)
                    return new RequestMessage<string>()
                    {
                        Message = "Processamento cancelado!",
                        StatusCode = System.Net.HttpStatusCode.BadRequest
                    };

                foreach (var nomeTabela in ParamtersInput.NomeTabelas)
                {
                    var local = salvar.SelectedPath + "I" + "\\";

                    var instancia = new ProcOracle(nomeTabela, new OracleTables().ListarAtributos(nomeTabela));

                    var header = instancia.GerarPackageHeader().ToString();
                    File.WriteAllText(local + $"{nomeTabela}Header.sql", header);

                    var body = instancia.GerarPackageBody().ToString();
                    File.WriteAllText(local + $"{nomeTabela}Body.sql", body);
                }

                return new RequestMessage<string>()
                {
                    Message = "Processamento concluído com sucesso!",
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new RequestMessage<string>()
                {
                    Message = "Falha no sistema!",
                    TechnicalMessage = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public RequestMessage<string> Generate(FolderBrowserDialog salvar)
        {
            if (!ParamtersInput.NomeTabelas.Any())
            {
                return new RequestMessage<string>()
                {
                    Message = "Selecione uma tabela",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }

            switch (ParamtersInput.SGBD)
            {
                case 1:
                    {
                        return Oracle(salvar);
                    }
            }

            return new RequestMessage<string>()
            {
                Message = "Selecione uma tabela",
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}
