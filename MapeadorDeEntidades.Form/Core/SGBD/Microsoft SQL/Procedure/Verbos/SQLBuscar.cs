using System;
using System.Collections.Generic;
using System.Text;
using MapeadorDeEntidades.Form.Core.SGBD.Microsoft_SQL.Procedure.Comum;

namespace MapeadorDeEntidades.Form.Core.SGBD.Microsoft_SQL.Procedure.Verbos
{
    public class SQLBuscar
    {
        private string N => Environment.NewLine;

        /// <summary>
        /// Adiciona no header da procedure o comando para dropar caso exista a procedure -
        /// Também adicionar o sumário
        /// </summary>
        /// <param name="nomeProcedure"></param>
        /// <param name="nomeTabela"></param>
        /// <param name="listaAtributos"></param>
        /// <returns></returns>
        public StringBuilder Init(string nomeProcedure, string nomeTabela, List<SQLEntidadeTabela> listaAtributos)
        {
            var desc = new StringBuilder();
            desc.Append(new SQLSumario().Init(nomeProcedure, nomeTabela));
            desc.Append("	BEGIN" + N + N);
            desc.Append(new SQLBuscaParamters().Init(nomeTabela, listaAtributos));
            desc.Append("	END" + N + N);
            desc.Append("GO" + N + N + N + N);
            return desc;
        }
    }
}
