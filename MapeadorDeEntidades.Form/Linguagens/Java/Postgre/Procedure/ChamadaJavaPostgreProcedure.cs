using System;
using System.IO;
using System.Windows.Forms;
using Zeus.Core;
using Zeus.Linguagens.Java.Oracle.Procedure;
using Zeus.Utilidade;

namespace Zeus.Linguagens.Java.Postgre.Procedure
{
    public class ChamadaJavaOracleProcedure
    {
        public RequestMessage<string> Java(FolderBrowserDialog salvar)
        {
            try
            {
                int max = ParamtersInput.NomeTabelas.Count;
                var i = 0;
                foreach (var nomeTabela in ParamtersInput.NomeTabelas)
                {

                    i++;
                    Util.Barra((int)((((decimal)i / max) * 100)));
                    Util.Status($"Processando tabela: {nomeTabela}");

                    var instancia = new JavaOracleProcedure(nomeTabela);

                    var classe = instancia.GerarClasse().ToString();
                    File.WriteAllText($"{salvar.SelectedPath}\\{nomeTabela.ToLower()}Dao.java", classe);
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
