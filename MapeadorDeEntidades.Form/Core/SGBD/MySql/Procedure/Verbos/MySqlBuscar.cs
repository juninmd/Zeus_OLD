using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapeadorDeEntidades.Form.Core.SGBD.MySql;
using MapeadorDeEntidades.Form.Core.SGBD.MYSQL.Procedure.Comum;

namespace MapeadorDeEntidades.Form.Core.SGBD.MYSQL.Procedure.Verbos
{
    public class MySqlBuscar
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
            desc.Append($" CREATE PROCEDURE `{nomeProcedure}` (IN P_{listaAtributos.First().COLUMN_NAME} {listaAtributos.First().DATA_TYPE})"+N);
            desc.Append("	BEGIN" + N + N);
            desc.Append(new MySqlBuscaParamters().Init(nomeTabela, listaAtributos));
            desc.Append("	END$$" + N + N);
            return desc;
        }

    }
}
