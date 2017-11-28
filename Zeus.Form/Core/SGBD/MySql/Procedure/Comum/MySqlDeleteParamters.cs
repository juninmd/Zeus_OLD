using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zeus.Core.SGBD.MySql.Procedure.Comum
{
    public class MySqlDeleteParamters
    {
        private string N => Environment.NewLine;

        public StringBuilder Init(string nomeTabela, List<MySqlEntidadeTabela> listaAtributos)
        {
            var param = new StringBuilder();
            var count = listaAtributos.Count;
            if (count == 0)
                return param;

            param.Append($"	     DELETE FROM {nomeTabela}{N}");
            param.Append($"               WHERE {listaAtributos.First().COLUMN_NAME} = P_{listaAtributos.First().COLUMN_NAME};{N}{N}");
            return param;
        }
    }
}
