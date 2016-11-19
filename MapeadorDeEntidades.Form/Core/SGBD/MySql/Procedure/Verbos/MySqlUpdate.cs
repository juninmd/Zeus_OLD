using System;
using System.Collections.Generic;
using System.Text;
using MapeadorDeEntidades.Form.Core.SGBD.MySql;
using MapeadorDeEntidades.Form.Core.SGBD.MYSQL.Procedure.Comum;

namespace MapeadorDeEntidades.Form.Core.SGBD.MYSQL.Procedure.Verbos
{
    public class MySqlUpdate
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
        public StringBuilder Init(string nomeProcedure, string nomeTabela, List<MySqlEntidadeTabela> listaAtributos)
        {
            var desc = new StringBuilder();
            desc.Append(new MySqlSumario().Init(nomeProcedure, nomeTabela, Paramters(listaAtributos)));
            desc.Append("	BEGIN" + N + N);
            desc.Append(new MySqlUpdateParamters().Init(nomeTabela, listaAtributos));
            desc.Append("	END" + N + N);
            desc.Append("GO" + N + N + N + N);
            return desc;
        }
        private StringBuilder Paramters(List<MySqlEntidadeTabela> parametro)
        {
            var count = parametro.Count;
            var desc = new StringBuilder();
            for (int i = 0; i < count - 1; i++)
            {
                desc.Append($"	@{parametro[i].COLUMN_NAME}        {parametro[i].DATA_TYPE},{N}");
            }
            desc.Append($"	@{parametro[count - 1].COLUMN_NAME}        {parametro[count - 1].DATA_TYPE}{N}");
            return desc;
        }
    }
}
