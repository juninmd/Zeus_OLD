using System;
using System.Collections.Generic;
using System.Text;
using Zeus.Core.SGBD.Microsoft_SQL;

namespace Zeus.Linguagens.CSharp.SQL.Procedure
{
    public class CSharpProcDeleteSQL
    {
        protected static string N => Environment.NewLine;

        #region ::: Delete :::
        public StringBuilder Init(string nomeProcedure, string NomeTabela, List<SQLEntidadeTabela> ListaAtributosTabela)
        {
            var methodo = new StringBuilder();
            methodo.Append(N);
            methodo.Append($"        public RequestMessage<string> Delete(int id, bool commit = false)" + N);
            methodo.Append("        {" + N + N);

            methodo.Append($"            BeginNewStatement(PackageName, Procedures.{nomeProcedure});" + N);

            methodo.Append(N);
            methodo.Append("            AddResult();" + N);
            methodo.Append("            AddParameter(\"ID\", id);" + N);
            methodo.Append(N + "            return RequestProc(GetClass.GetMethod(), commit);" + N);
            methodo.Append("        }" + N);
            methodo.Append(N);
            return methodo;
        }

        #endregion
    }
}
