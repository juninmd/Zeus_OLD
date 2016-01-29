using System.Collections.Generic;
using System.Net;

namespace MapeadorDeEntidades.Form
{
    public class RequestMessage
    {
        public RequestMessage()
        {
            StatusCode = HttpStatusCode.OK;
        }

        /// <summary>
        /// Entidade responsável por dar override no dropdown de ação.
        /// </summary>
        public AcaoOverride AcaoOverride { get; set; }


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
        /// Controller / Action 
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Tipo do Status code de Erro
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// <para>Caso o Status Code esteja OK ou Accepted = Sucesso</para>
        /// </summary>
        public bool IsSuccess => StatusCode == HttpStatusCode.Accepted || StatusCode == HttpStatusCode.OK;

        /// <summary>
        /// <para>Caso a requisição tenha dado algum erro e seja diferente de Accepted | OK | No Content </para>
        /// </summary>
        public bool IsError => !(StatusCode == HttpStatusCode.Accepted || StatusCode == HttpStatusCode.OK || StatusCode == HttpStatusCode.NoContent);

        #region Tipos de retorno para tratamento no JS 

        /// <summary>
        /// Caso ativado, significa um erro da ApiGee ao consultar algum protocolo.
        /// </summary>
        public bool IsErrorInApiGee { get; set; }


        /// <summary>
        /// Caso Ativado, não vai cair nos método de validação do Jquery Global.
        /// </summary>
        public bool Custom { get; set; }

        /// <summary>
        /// Caso Ativado, exibe somente a mensagem do Erro em um alert.
        /// </summary>
        public bool OnlyMessage { get; set; }

        /// <summary>
        /// Caso Ativado, indica um erro inesperado pelo sistema / Global Exception.
        /// </summary>
        public bool Global { get; set; }
        #endregion

    }

    /// <summary>
    /// Classe responsável pelo retorno das requisições do Sistema.
    /// Sendo via WebApi ou Procedures
    /// </summary>
    /// <typeparam name="T">Entidade esperada pelo retorno</typeparam>
    public class RequestMessage<T> : RequestMessage
    {
        /// <summary>
        /// <para>Conteudo da Requisição da API</para>
        /// <para>Ele não é retornado para o navegador em JSON</para> 
        /// </summary>
        public T Content { get; set; }

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

        /// <summary>
        /// Parametros header
        /// </summary>
        public List<Paramters> Headers { get; set; }


    }

    public class Paramters
    {
        /// <summary>
        /// Nome do parametro header 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Valor do parametro
        /// </summary>
        public object Value { get; set; }
    }


    /// <summary>
    /// <para>Classe responsável por trocar o valor do dropdown de ação.</para>
    /// <para>Alterando descrição e id, pesquisando pelo id antigo.</para>
    /// </summary>
    public class AcaoOverride
    {
        /// <summary>
        /// Descrição da Acao.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Novo valor da ação.
        /// </summary>
        public int Value => 000;

        /// <summary>
        /// Valor antigo da ação a ser trocada.
        /// </summary>
        public int OldValue { get; set; }
    }
}
