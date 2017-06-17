﻿using System.Text;
using Zeus.Linguagens.Base;
using Zeus.Properties;

namespace Zeus.Linguagens.CSharp.Firebird.Procedure
{
    public class CSharpFirebirdProcedure : BaseMySqlDAO
    {
        public CSharpFirebirdProcedure(string nomeTabela) : base(nomeTabela)
        {
        }

        #region CLASSE 

        public StringBuilder GerarClasse()
        {
            var nomeProcBase = NomeTabela.Replace(Settings.Default.PrefixoTabela, "");

            var classe = new StringBuilder();
            classe.Append("using System.Net;" + N);
            classe.Append("using System;" + N + N);
            classe.Append("namespace MapeadorDeEntidades.Form" + N);
            classe.Append("{" + N);
            classe.Append($"    public class {nomeProcBase.ToLowerInvariant()}RequestRepository : ADORepository" + N);
            classe.Append("    {" + N + N);
            classe.Append($"        private const string PackageName = \"{NomeTabela.Replace("_T_", "_PG_")}\";" + N + N);
            classe.Append(Procedures(nomeProcBase));
            classe.Append(GetById(nomeProcBase));
            classe.Append(Add(nomeProcBase));
            classe.Append(Update(nomeProcBase));

            classe.Append("    }" + N);
            classe.Append("}" + N);

            return classe;
        }

        #region ::: Enum Procedures :::

        private StringBuilder Procedures(string nomeProcBase)
        {
            var proc = new StringBuilder();
            proc.Append(N);
            proc.Append("        private enum Procedures" + N);
            proc.Append("        {" + N);
            proc.Append($"            S_{nomeProcBase}," + N);
            proc.Append($"            S_{nomeProcBase}_ID," + N);
            proc.Append($"            I_{nomeProcBase}," + N);
            proc.Append($"            U_{nomeProcBase}," + N);
            proc.Append($"            D_{nomeProcBase}" + N);
            proc.Append("        }" + N + N);
            return proc;
        }

        #endregion

        #region ::: Get By ID :::
        private StringBuilder GetById(string nomeProcedure)
        {
            var methodo = new StringBuilder();
            methodo.Append(N);
            methodo.Append($"        public RequestMessage<{NomeTabela}> GetById(long ID)" + N);
            methodo.Append("        {" + N);
            methodo.Append($"            var result = new RequestMessage<{NomeTabela}>" + N);
            methodo.Append("            {" + N);
            methodo.Append($"                Procedure = $\"{{PackageName}}.{{Procedures.S_{nomeProcedure}}}\"," + N);
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
            methodo.Append(GetListaItensGetById());
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

        private StringBuilder GetListaItensGetById()
        {
            var atributoText = new StringBuilder();
            foreach (var item in ListaAtributosTabela)
            {
                atributoText.Append($"                        {item.COLUMN_NAME} = \"{item.COLUMN_NAME}\".GetValueOrDefault<{CSharpTypesFirebird.GetTypeAtribute(item.DATA_TYPE, item.IS_NULLABLE == "Y")}>(reader)," + N);
            }
            return atributoText;
        }
        #endregion

        #region ::: ADD :::
        private StringBuilder Add(string nomeProcedure)
        {
            var methodo = new StringBuilder();
            methodo.Append(N);
            methodo.Append($"        public RequestMessage<string> Add({NomeTabela} entidade, bool commit = false)" + N);
            methodo.Append("        {" + N + N);

            methodo.Append($"            BeginNewStatement(PackageName, Procedures.MAG_SP_PDL_I_{nomeProcedure});" + N);

            methodo.Append(N);
            methodo.Append("            AddResult();" + N);
            methodo.Append(GetListaItensAdd());
            methodo.Append(N + "            return RequestProc(GetClass.GetMethod(), commit);" + N);
            methodo.Append("        }" + N);
            methodo.Append(N);
            return methodo;
        }

        private StringBuilder GetListaItensAdd()
        {
            var atributoText = new StringBuilder();
            foreach (var item in ListaAtributosTabela)
            {
                atributoText.Append($"            AddParameter(\"{item.COLUMN_NAME}\", entidade.{item.COLUMN_NAME});" + N);
            }
            return atributoText;
        }

        #endregion

        #region ::: UPDATE :::
        private StringBuilder Update(string nomeProcedure)
        {
            var methodo = new StringBuilder();
            methodo.Append(N);
            methodo.Append($"        public RequestMessage<string> Update({NomeTabela} entidade, bool commit = false)" + N);
            methodo.Append("        {" + N + N);

            methodo.Append($"            BeginNewStatement(PackageName, Procedures.MAG_SP_PDL_U_{nomeProcedure});" + N);

            methodo.Append(N);
            methodo.Append("            AddResult();" + N);
            methodo.Append(GetListaItensAdd());
            methodo.Append(N + "            return RequestProc(GetClass.GetMethod(), commit);" + N);
            methodo.Append("        }" + N);
            methodo.Append(N);
            return methodo;
        }

        #endregion

        #endregion

        public StringBuilder GerarInterfaceSharProc()
        {
            var nomeProcBase = NomeTabela.Replace(Settings.Default.PrefixoTabela, "");

            var classe = new StringBuilder();
            classe.Append("using System;" + N + N);
            classe.Append("namespace MapeadorDeEntidades.Form" + N);
            classe.Append("{" + N);
            classe.Append($"    public interface {nomeProcBase.ToLowerInvariant()}RequestRepository : IADORepository" + N);
            classe.Append("    {" + N + N);
            classe.Append(GetInterfacesMethod());
            classe.Append("    }" + N);
            classe.Append("}" + N);

            return classe;
        }

        private StringBuilder GetInterfacesMethod()
        {
            var assinatura = new StringBuilder();
            assinatura.Append($"        RequestMessage<{NomeTabela}> GetById(long ID);" + N + N);
            assinatura.Append($"        RequestMessage<string> Add({NomeTabela} entidade, bool commit = false);" + N + N);
            assinatura.Append($"        RequestMessage<string> Update({NomeTabela} entidade, bool commit = false);" + N + N);
            return assinatura;
        }
    }
}