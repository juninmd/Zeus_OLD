using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapeadorDeEntidades.Form.Core.SGBD.Microsoft_SQL.Procedure.Comum;

namespace MapeadorDeEntidades.Form.Core.SGBD.Microsoft_SQL.Procedure.Verbos
{
    public class SQLDelete
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
            desc.Append(new SQLSumario().Init(nomeProcedure, nomeTabela, Paramters(listaAtributos.First())));
            desc.Append("	BEGIN" + N + N);
            desc.Append(new SQLDeleteParamters().Init(nomeTabela, listaAtributos));
            desc.Append("	END" + N + N);
            desc.Append("GO" + N + N + N + N);
            return desc;
        }
        private StringBuilder Paramters(SQLEntidadeTabela parametro)
        {
            var desc = new StringBuilder();
            desc.Append($"	@{parametro.COLUMN_NAME}        {parametro.DATA_TYPE}{N}");
            return desc;
        }
    }
}
