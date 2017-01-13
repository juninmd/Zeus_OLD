using System;
using System.Text;

namespace Zeus.Core.SGBD.Microsoft_SQL.Procedure.Comum
{
    public class SQLSumario
    {
        private string N => Environment.NewLine;

        /// <summary>
        /// Adiciona no header da procedure o comando para dropar caso exista a procedure -
        /// Também adicionar o sumário
        /// </summary>
        /// <param name="nomeProcedure"></param>
        /// <param name="nomeTabela"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public StringBuilder Init(string nomeProcedure, string nomeTabela, StringBuilder parametros = null)
        {
            var desc = new StringBuilder();
            desc.Append(N);
            desc.Append($"IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'{nomeProcedure}') AND objectproperty(id, N'IsPROCEDURE')=1)" + N);
            desc.Append($"	DROP PROCEDURE {nomeProcedure}" + N);
            desc.Append("GO" + N + N);
            desc.Append($"CREATE PROCEDURE {nomeProcedure}" + N);

            if (parametros?.Length > 0)
                desc.Append(parametros);

            desc.Append($"	AS" + N);
            desc.Append(N);
            desc.Append("	/*" + N);
            desc.Append("	Documentação" + N);
            desc.Append($"	Arquivo Fonte.....: {nomeTabela.TratarNomeSQL()}.sql" + N);
            desc.Append($"	Objetivo..........:" + N);
            desc.Append($"	Autor.............:" + N);
            desc.Append($"	Data..............: {DateTime.Now.ToShortDateString()}" + N);
            desc.Append($"	Ex................: EXEC {nomeProcedure}" + N);
            desc.Append("	*/" + N + N);
            return desc;
        }
    }
}
