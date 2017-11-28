using System;
using System.Collections.Generic;
using System.Text;
using Zeus.Core.SGBD.Microsoft_SQL;

namespace Zeus.Linguagens.CSharp.SQL.Procedure
{
    public class CSharpProcPostSQL
    {
        protected static string N => Environment.NewLine;

        #region ::: ADD :::
        public StringBuilder Init(string nomeProcedure, string NomeTabela, List<SQLEntidadeTabela> ListaAtributosTabela)
        {
            var methodo = new StringBuilder();
            methodo.Append(N);
            methodo.Append($"        public RequestMessage<string> Add({NomeTabela} entidade, bool commit = false)" + N);
            methodo.Append("        {" + N + N);

            methodo.Append($"            BeginNewStatement(PackageName, Procedures.{nomeProcedure});" + N);

            methodo.Append(N);
            methodo.Append("            AddResult();" + N);
            methodo.Append(GetListaItensAdd(ListaAtributosTabela));
            methodo.Append(N + "            return RequestProc(GetClass.GetMethod(), commit);" + N);
            methodo.Append("        }" + N);
            methodo.Append(N);
            return methodo;
        }

        private StringBuilder GetListaItensAdd(List<SQLEntidadeTabela> ListaAtributosTabela)
        {
            var atributoText = new StringBuilder();
            foreach (var item in ListaAtributosTabela)
            {
                atributoText.Append($"            AddParameter(\"{item.COLUMN_NAME}\", entidade.{item.COLUMN_NAME});" + N);
            }
            return atributoText;
        }

        #endregion
    }
}
