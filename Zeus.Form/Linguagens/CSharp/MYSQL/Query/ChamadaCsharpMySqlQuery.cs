using System;
using System.IO;
using Zeus.Core;
using Zeus.Utilidade;

namespace Zeus.Linguagens.CSharp.MYSQL.Query
{
    public class ChamadaCsharpMySqlQuery
    {
        public RequestMessage<string> CSharp()
        {
            try
            {
                int max = ParamtersInput.NomeTabelas.Count;
                var i = 0;
                var local = ParamtersInput.SelectedPath;

                foreach (var nomeTabela in ParamtersInput.NomeTabelas)
                {
                    i++;
                    Util.Barra((int)((((decimal)i / max) * 100)));
                    Util.Status($"Processando tabela: {nomeTabela}");


                    var instancia = new CsharpMySqlQuery(nomeTabela);

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
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    StackTrace = ex.StackTrace
                };
            }
        }
    }
}
