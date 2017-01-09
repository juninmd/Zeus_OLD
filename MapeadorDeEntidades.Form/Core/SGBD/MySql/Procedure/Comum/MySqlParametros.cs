using System.Collections.Generic;
using System.Text;

namespace MapeadorDeEntidades.Form.Core.SGBD.MySql.Procedure.Comum
{
    public class MySqlParametros
    {
        public StringBuilder GenerateParams(List<MySqlEntidadeTabela> parametro, bool full)
        {
            if (parametro.Count == (full ? 0 : 1))
                return new StringBuilder();

            var desc = new StringBuilder();

            for (int index = (full ? 0 : 1); index < parametro.Count; index++)
            {
                var item = parametro[index];
                desc.Append($"IN P_{item.COLUMN_NAME} {item.DATA_TYPE}{Virgula(parametro.Count, index, full)}");
            }
            return desc;
        }


        private StringBuilder Virgula(int count, int index, bool full)
        {
            if (count != (full ? 0 : 1) && index != (count - 1))
                return new StringBuilder(", ");
            return new StringBuilder("");

        }
    }
}
