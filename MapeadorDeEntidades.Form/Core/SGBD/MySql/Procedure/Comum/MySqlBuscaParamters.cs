using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapeadorDeEntidades.Form.Core.SGBD.Microsoft_SQL;
using MapeadorDeEntidades.Form.Core.SGBD.MySql;

namespace MapeadorDeEntidades.Form.Core.SGBD.MYSQL.Procedure.Comum
{
    public class MySqlBuscaParamters
    {
        private string N => Environment.NewLine;

        public StringBuilder Init(string nomeTabela, List<MySqlEntidadeTabela> listaAtributos)
        {
            var param = new StringBuilder();
            var count = listaAtributos.Count;
            if (count == 0)
                return param;

            param.Append("	     SELECT"+N);
            foreach (var item in listaAtributos)
            {
                param.Append($"	     {item.COLUMN_NAME}," + N);
            }
            param.Append($"	     FROM {nomeTabela}" + N);
            param.Append($"	     WHERE {listaAtributos.First().COLUMN_NAME} = {listaAtributos.First().COLUMN_NAME}" + N);
            return param;
        }
    }
}
