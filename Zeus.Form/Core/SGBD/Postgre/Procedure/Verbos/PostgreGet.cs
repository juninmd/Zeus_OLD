﻿using System;
using System.Collections.Generic;
using System.Text;
using Zeus.Core.SGBD.Postgre.Procedure.Comum;

namespace Zeus.Core.SGBD.Postgre.Procedure.Verbos
{
    public class PostgreGet
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
        public StringBuilder Init(string nomeProcedure, string nomeTabela, List<PostgreEntidadeTabela> listaAtributos)
        {
            var desc = new StringBuilder();
            desc.Append(new PostgreSumario().Init(nomeProcedure, nomeTabela));
            desc.Append($" CREATE PROCEDURE `{nomeProcedure}` ()" + N);
            desc.Append("	BEGIN" + N + N);
            desc.Append(new PostgreSelectParamters().Init(nomeTabela, listaAtributos));
            desc.Append("	END$$" + N + N);
            return desc;
        }
    }
}