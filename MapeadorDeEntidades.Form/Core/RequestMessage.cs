using System.Net;

namespace MapeadorDeEntidades.Form.Core
{
    public class RequestMessage
    {
        public RequestMessage()
        {
            StatusCode = HttpStatusCode.OK;
        }

        public bool IsError => StatusCode != HttpStatusCode.OK;

        /// <summary>
        /// Mensagem do Erro
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Mensagem de Erro / Tecnica
        /// </summary>
        public string TechnicalMessage { get; set; }

        /// <summary>
        /// Indica a linha na qual aconteceu algum erro na aplicação
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// Tipo do Status code de Erro
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
      

        /// <summary>
        /// Nome do Package + Procedure
        /// </summary>
        public string Procedure { get; set; }

        /// <summary>
        /// Método da Requisição API
        /// </summary>
        public string MethodApi { get; set; }

        /// <summary>
        /// Nome do parametro de retorno da Procedure
        /// </summary>
        public string Parameter { get; set; }

        /// <summary>
        /// Url da Requisição API
        /// </summary>
        public string UrlApi { get; set; }

    }
    public class RequestMessage<T> : RequestMessage
    {
        /// <summary>
        /// <para>Conteudo da Requisição da API</para>
        /// <para>Ele não é retornado para o navegador em JSON</para> 
        /// </summary>
        public T Content { get; set; }
    }
   
}
