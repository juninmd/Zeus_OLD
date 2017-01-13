using System;
using System.Collections.Generic;
using System.Text;
using Zeus.Core.SGBD.Microsoft_SQL;

namespace Zeus.Linguagens.CSharp.SQL.Procedure
{
    public class CSharpProcGetAllSQL
    {
        protected static string N => Environment.NewLine;

        #region ::: Get ALL :::
        public StringBuilder Init(string nomeProcedure, string NomeTabela, List<SQLEntidadeTabela> ListaAtributosTabela)
        {
            var methodo = new StringBuilder();
            methodo.Append(N);
            methodo.Append($"        public RequestMessage<{NomeTabela}> GetById(long id)" + N);
            methodo.Append("        {" + N);
            methodo.Append($"            var result = new RequestMessage<{NomeTabela}>" + N);
            methodo.Append("            {" + N);
            methodo.Append($"                Procedure = $\"{{PackageName}}.{{Procedures.{nomeProcedure}}}\"," + N);
            methodo.Append($"                MethodApi = GetClass.GetMethod()" + N);
            methodo.Append("            };" + N);
            methodo.Append(N);
            methodo.Append("            BeginNewStatement(result.Procedure);" + N);
            methodo.Append("            AddParameter(\"ID\", ID);" + N);
            methodo.Append(N);
            methodo.Append("            OpenConnection();" + N);
            methodo.Append("            using (var reader = ExecuteReader())" + N);
            methodo.Append("            {" + N);
            methodo.Append("                if (reader.Read())" + N);
            methodo.Append($"               {{" + N);
            methodo.Append($"                    result.Content = new {NomeTabela}" + N);
            methodo.Append("                    {" + N);
            methodo.Append(GetListaItensGetById(ListaAtributosTabela));
            methodo.Append("                    };" + N);
            methodo.Append("                return result;" + N);
            methodo.Append($"               }}" + N);
            methodo.Append("            }" + N);
            methodo.Append(N);
            methodo.Append("            result.Message = $\"O request de {ID} não foi encontrada.\";" + N);
            methodo.Append("            result.StatusCode = HttpStatusCode.NoContent;" + N);
            methodo.Append($"            result.Content = new {NomeTabela}();" + N);
            methodo.Append(N);
            methodo.Append("            return result;" + N);
            methodo.Append("       }" + N);
            methodo.Append(N);
            return methodo;
        }

        private StringBuilder GetListaItensGetById(List<SQLEntidadeTabela> ListaAtributosTabela)
        {
            var atributoText = new StringBuilder();
            foreach (var item in ListaAtributosTabela)
            {
                atributoText.Append($"                        {item.COLUMN_NAME} = \"{item.COLUMN_NAME}\".GetValueOrDefault<{CSharpTypesSQL.GetTypeAtribute(item.DATA_TYPE, item.NULLABLE)}>(reader)," + N);
            }
            return atributoText;
        }
        #endregion
    }
}
