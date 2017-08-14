using System;
using System.IO;
using System.Linq;
using Zeus.Properties;
using Zeus.Utilidade;

namespace Zeus.Core.SGBD.Oracle.Batch
{
    public class OracleOrquestradorBatch
    {
        public RequestMessage<string> Oracle()
        {
            try
            {

                var files = Directory.GetFiles(ParamtersInput.SelectedPath).OrderByDescending(q => q).ToList();
                int max = files.Count;
                var i = 0;

                foreach (var nomeArquivo in files)
                {
                    i++;
                    Util.Barra((int)((((decimal)i / max) * 100)));
                    Util.Status($"Processando Arquivo: {nomeArquivo}");


                    var nomePG = Path.GetFileNameWithoutExtension(nomeArquivo);
                    if (nomePG.Contains((Settings.Default.PrefixoPackage)))
                    {

                        var body = nomePG.Contains("_BODY");
                        if (new OracleBatchSkip().Package(nomePG.Replace("_BODY", "").Replace("_HEADER", ""), body).IsError)
                            continue;
                    }

                    if (nomePG.Contains("_SEQUENCE"))
                    {
                        var nomeSequence = nomePG.Replace("_SEQUENCE", "").TratarNomeSequence().Replace(".NEXTVAL", "");
                        if (new OracleBatchSkip().Sequence(nomeSequence).IsError)
                            continue;
                    }

                    if (nomePG.Contains("_RELATIONAL") || nomePG.Contains("Repository"))
                    {
                        continue;
                    }

                    var instancia = new OracleBatch().Init(File.ReadAllText($"{nomeArquivo}"));
                    if (instancia.IsError)
                    {
                        return instancia;
                    }
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