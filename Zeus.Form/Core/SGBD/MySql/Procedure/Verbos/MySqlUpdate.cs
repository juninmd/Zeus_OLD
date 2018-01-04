using System;
using System.Collections.Generic;
using System.Text;
using Zeus.Core.SGBD.MySql.Procedure.Comum;

namespace Zeus.Core.SGBD.MySql.Procedure.Verbos
{
    public class MySqlUpdate
    {
        private string N => Environment.NewLine;

        /// <summary>
        ///     Adiciona no header da procedure o comando para dropar caso exista a procedure -
        ///     Também adicionar o sumário
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
            desc.Append(new MySqlUpdateParamters().Init(nomeTabela, listaAtributos));
            desc.Append("	END$$" + N + N);
            return desc;
        }

        private StringBuilder Paramters(List<MySqlEntidadeTabela> parametro)
        {
            return new MySqlParametros().GenerateParams(parametro, true);
        }
    }
}