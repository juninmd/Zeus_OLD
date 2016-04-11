using MapeadorDeEntidades.Form.Core;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MapeadorDeEntidades.Form.Middleware
{
    public class MD_ChamadaProc
    {

        private RequestMessage<string> CSharp(FolderBrowserDialog salvar)
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

                    var instancia = new CSharpADO(nomeTabela);

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

            switch (ParamtersInput.Linguagem)
            {
                case 1:
                    {
                        return CSharp(salvar);
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
