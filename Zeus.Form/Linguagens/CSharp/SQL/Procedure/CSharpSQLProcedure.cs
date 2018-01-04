using System.Collections.Generic;
using System.Text;
using Zeus.Core;
using Zeus.Core.SGBD.Microsoft_SQL;
using Zeus.Linguagens.Base;

namespace Zeus.Linguagens.CSharp.SQL.Procedure
{
    public class CSharpSQLProcedure : BaseSQLDAO
    {
        public CSharpSQLProcedure(string NomeTabela) : base(NomeTabela)
        {
        }

        #region CLASSE 

        public StringBuilder GerarClasse()
        {
            var nomeProcBase = NomeTabela;

            var classe = new StringBuilder();
            classe.Append("using System.Net;" + N);
            classe.Append("using System;" + N + N);
            classe.Append("namespace MeuProjeto" + N);
            classe.Append("{" + N);
            classe.Append($"    public class {nomeProcBase}RequestRepository : ADORepository" + N);
            classe.Append("    {" + N + N);
            classe.Append($"        private const string PackageName = \"Package{nomeProcBase}\";" + N + N);
            classe.Append(Procedures(nomeProcBase));
            classe.Append(GetAll($"Sel{nomeProcBase}", nomeProcBase, ListaAtributosTabela));
            classe.Append(GetById($"Busca{nomeProcBase}", nomeProcBase, ListaAtributosTabela));
            classe.Append(Insert($"Ins{nomeProcBase}", nomeProcBase, ListaAtributosTabela));
            classe.Append(Update($"Upd{nomeProcBase}", nomeProcBase, ListaAtributosTabela));
            classe.Append(Delete($"Delete{nomeProcBase}", nomeProcBase, ListaAtributosTabela));
            classe.Append("    }" + N);
            classe.Append("}" + N);

            return classe;
        }

        #endregion

        #region ::: Enum Procedures :::

        private StringBuilder Procedures(string nomeProcBase)
        {
            var proc = new StringBuilder();
            proc.Append(N);
            proc.Append("        private enum Procedures" + N);
            proc.Append("        {" + N);
            proc.Append($"		{nomeProcBase.TratarNomeProcedure(OperationProcedure.Search)},{N}");
            proc.Append($"		{nomeProcBase.TratarNomeProcedure(OperationProcedure.List)},{N}");
            proc.Append($"		{nomeProcBase.TratarNomeProcedure(OperationProcedure.Insert)},{N}");
            proc.Append($"		{nomeProcBase.TratarNomeProcedure(OperationProcedure.Update)},{N}");
            proc.Append($"		{nomeProcBase.TratarNomeProcedure(OperationProcedure.Delete)}{N}");
            proc.Append("        }" + N + N);
            return proc;
        }

        #endregion


        public StringBuilder GerarInterfaceSharProc()
        {
            var nomeProcBase = NomeTabela;

            var classe = new StringBuilder();
            classe.Append("using System;" + N + N);
            classe.Append("namespace MeuProjeto" + N);
            classe.Append("{" + N);
            classe.Append($"    public interface {nomeProcBase}Repository : IADORepository" + N);
            classe.Append("    {" + N + N);
            classe.Append(GetInterfacesMethod());
            classe.Append("    }" + N);
            classe.Append("}" + N);

            return classe;
        }

        private StringBuilder GetInterfacesMethod()
        {
            var assinatura = new StringBuilder();
            assinatura.Append($"        RequestMessage<{NomeTabela}> GetById(long id);" + N + N);
            assinatura.Append($"        RequestMessage<List<{NomeTabela}>> GetAll();" + N + N);
            assinatura.Append(
                $"        RequestMessage<string> Add({NomeTabela} entidade, bool commit = false);" + N + N);
            assinatura.Append($"        RequestMessage<string> Update({NomeTabela} entidade, bool commit = false);" +
                              N + N);
            assinatura.Append($"        RequestMessage<string> Delete(long id, bool commit = false);" + N + N);
            return assinatura;
        }

        #region ::: Delete :::

        public StringBuilder Delete(string nomeProcedure, string NomeTabela,
            List<SQLEntidadeTabela> ListaAtributosTabela)
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

        #region ::: Get By ID :::

        public StringBuilder GetById(string nomeProcedure, string NomeTabela,
            List<SQLEntidadeTabela> ListaAtributosTabela)
        {
            var methodo = new StringBuilder();
            methodo.Append(N);
            methodo.Append($"        public RequestMessage<{NomeTabela}> GetById(long ID)" + N);
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

        #endregion

        #region ::: ADD :::

        public StringBuilder Insert(string nomeProcedure, string NomeTabela,
            List<SQLEntidadeTabela> ListaAtributosTabela)
        {
            var methodo = new StringBuilder();
            methodo.Append(N);
            methodo.Append($"        public RequestMessage<string> Add({NomeTabela} entidade, bool commit = false)" +
                           N);
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

        #endregion

        #region ::: Get ALL :::

        public StringBuilder GetAll(string nomeProcedure, string NomeTabela,
            List<SQLEntidadeTabela> ListaAtributosTabela)
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
                atributoText.Append(
                    $"                        {item.COLUMN_NAME} = \"{item.COLUMN_NAME}\".GetValueOrDefault<{CSharpTypesSQL.GetTypeAtribute(item.DATA_TYPE, item.IS_NULLABLE)}>(reader)," +
                    N);
            return atributoText;
        }

        #endregion

        #region ::: UPDATE :::

        public StringBuilder Update(string nomeProcedure, string NomeTabela,
            List<SQLEntidadeTabela> ListaAtributosTabela)
        {
            var methodo = new StringBuilder();
            methodo.Append(N);
            methodo.Append($"        public RequestMessage<string> Update({NomeTabela} entidade, bool commit = false)" +
                           N);
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
                atributoText.Append($"            AddParameter(\"{item.COLUMN_NAME}\", entidade.{item.COLUMN_NAME});" +
                                    N);
            return atributoText;
        }

        #endregion
    }
}