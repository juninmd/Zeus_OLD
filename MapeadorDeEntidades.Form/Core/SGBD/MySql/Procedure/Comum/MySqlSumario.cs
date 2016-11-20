using System;
using System.Text;

namespace MapeadorDeEntidades.Form.Core.SGBD.MYSQL.Procedure.Comum
{
    public class MySqlSumario
    {
        private string N => Environment.NewLine;

        /// <summary>
        /// Adiciona no header da procedure o comando para dropar caso exista a procedure -
        /// Também adicionar o sumário
        /// </summary>
        /// <param name="nomeProcedure"></param>
        /// <param name="nomeTabela"></param>
        /// <returns></returns>
        public StringBuilder Init(string nomeProcedure, string nomeTabela)
        {
            var desc = new StringBuilder();
            desc.Append(N);
            desc.Append($"DROP procedure IF EXISTS `{nomeProcedure}`;" + N);
            desc.Append("	/*" + N);
            desc.Append("	Documentação" + N);
            desc.Append($"	Data..............: {DateTime.Now.ToShortDateString()}" + N);
            desc.Append($"	Ex................: EXEC {nomeProcedure}" + N);
            desc.Append("	*/" + N + N);
            return desc;
        }
    }
}
