using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapeadorDeEntidades.Form.Core.SGBD.MySql;
using MapeadorDeEntidades.Form.Core.SGBD.MYSQL.Procedure.Comum;

namespace MapeadorDeEntidades.Form.Core.SGBD.MYSQL.Procedure.Verbos
{
    public class MySqlInsert
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
            desc.Append(new MySqlSumario().Init(nomeProcedure, nomeTabela));
            desc.Append($" CREATE PROCEDURE `{nomeProcedure}` ({Paramters(listaAtributos)})" + N);
            desc.Append("	BEGIN" + N + N);
            desc.Append(new MySqlInsertParamters().Init(nomeTabela, listaAtributos));
            desc.Append("	END" + N + N);
            return desc;
        }

        private StringBuilder Paramters(List<MySqlEntidadeTabela> parametro)
        {
            var desc = new StringBuilder();

            if (parametro.Count == 1)
                return desc;

            for (int index = 1; index < parametro.Count; index++)
            {
                var item = parametro[index];
                desc.Append($"IN {item.COLUMN_NAME} {item.DATA_TYPE}{(index == parametro.Count || parametro.Count == 1 ? "" : $",{N}")}");
            }
            return desc;
        }

    }
}
