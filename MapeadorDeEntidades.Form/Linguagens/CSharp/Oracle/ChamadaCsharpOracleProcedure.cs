using System;
using System.IO;
using System.Windows.Forms;
using MapeadorDeEntidades.Form.Core;

namespace MapeadorDeEntidades.Form.Linguagens.CSharp.Oracle
{
    public class ChamadaCsharpOracleProcedure
    {
        public RequestMessage<string> CSharp(FolderBrowserDialog salvar)
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
                    var local = salvar.SelectedPath + "\\";

                    var instancia = new CSharpOracleRepository(nomeTabela);

                    var classe = instancia.GerarBodyCSharpProc().ToString();
                    File.WriteAllText(local + nomeTabela.ToLower() + "Repository.cs", classe);


                    var interfacename = instancia.GerarInterfaceSharProc().ToString();
                    File.WriteAllText(local + "I" + nomeTabela.ToLower() + "Repository.cs", interfacename);
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
    }
}
