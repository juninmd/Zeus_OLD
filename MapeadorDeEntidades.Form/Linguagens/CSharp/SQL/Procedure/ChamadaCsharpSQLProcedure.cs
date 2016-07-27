using System;
using System.IO;
using System.Windows.Forms;
using MapeadorDeEntidades.Form.Core;
using MapeadorDeEntidades.Form.Utilidade;

namespace MapeadorDeEntidades.Form.Linguagens.CSharp.SQL.Procedure
{
    public class ChamadaCsharpSQLProcedure
    {
        public RequestMessage<string> CSharp(FolderBrowserDialog salvar)
        {
            try
            {
                int max = ParamtersInput.NomeTabelas.Count;
                var i = 0;
                var local = salvar.SelectedPath + "\\";

                foreach (var nomeTabela in ParamtersInput.NomeTabelas)
                {
                    i++;
                    Util.Barra((int)((((decimal)i / max) * 100)));
                    Util.Status($"Processando tabela: {nomeTabela}");


                    var instancia = new CSharpProcSQL(nomeTabela);

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
