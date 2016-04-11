using System;
using System.Collections.Generic;
using System.Text;

namespace MapeadorDeEntidades.Form
{
    public class CSharpADO
    {
        public string IsNullabe(string aceitaNull)
        {
            return aceitaNull == "Y" ? "?" : "";
        }
        public string GetTypeAtribute(string tipoAttr, string aceitaNull)
        {
            switch (tipoAttr)
            {
                case "DATE":
                    return "DateTime" + IsNullabe(aceitaNull);
                case "NUMBER":
                    return "long" + IsNullabe(aceitaNull);
                default:
                    return "string";
            }
        }

        public string NomeTabela { get; set; }

        public List<EntidadeTabela> ListaAtributosTabela => new OracleTables().ListarAtributos(NomeTabela);

        public CSharpADO(string nomeTabela)
        {
            NomeTabela = nomeTabela;
        }

        #region CLASSE 

        public StringBuilder GerarBodyCSharpProc()
        {
            var nomeProcBase = NomeTabela.Replace("MAG_T_PDL", "").Replace("_", "");

            var classe = new StringBuilder();
            classe.Append("using System.Net;" + Environment.NewLine);
            classe.Append("using PagamentoDespesasLojas.Domain.Helpers;" + Environment.NewLine);
            classe.Append("using PagamentoDespesasLojas.Infra.Data;" + Environment.NewLine);
            classe.Append("using System;" + Environment.NewLine + Environment.NewLine);
            classe.Append("namespace MapeadorDeEntidades.Form" + Environment.NewLine);
            classe.Append("{" + Environment.NewLine);
            classe.Append($"    public class {nomeProcBase.ToLowerInvariant()}RequestRepository : ADORepository" + Environment.NewLine);
            classe.Append("    {" + Environment.NewLine + Environment.NewLine);
            classe.Append($"        private const string PackageName = \"{NomeTabela.Replace("_T_", "_PG_")}\";" + Environment.NewLine + Environment.NewLine);
            classe.Append(Procedures(nomeProcBase));
            classe.Append(GetById(nomeProcBase));
            classe.Append(Add(nomeProcBase));
            classe.Append(Update(nomeProcBase));

            classe.Append("    }" + Environment.NewLine);
            classe.Append("}" + Environment.NewLine);

            return classe;
        }

        #region ::: Enum Procedures :::

        private StringBuilder Procedures(string nomeProcBase)
        {
            var proc = new StringBuilder();
            proc.Append(Environment.NewLine);
            proc.Append("        private enum Procedures" + Environment.NewLine);
            proc.Append("        {" + Environment.NewLine);
            proc.Append($"            MAG_SP_PDL_S_{nomeProcBase}," + Environment.NewLine);
            proc.Append($"            MAG_SP_PDL_I_{nomeProcBase}," + Environment.NewLine);
            proc.Append($"            MAG_SP_PDL_U_{nomeProcBase}" + Environment.NewLine);
            proc.Append("        }" + Environment.NewLine + Environment.NewLine);
            return proc;
        }

        #endregion

        #region ::: Get By ID :::
        private StringBuilder GetById(string nomeProcedure)
        {
            var methodo = new StringBuilder();
            methodo.Append(Environment.NewLine);
            methodo.Append($"        public RequestMessage<{NomeTabela}> GetById(long idProcesso)" + Environment.NewLine);
            methodo.Append("        {" + Environment.NewLine);
            methodo.Append($"            var result = new RequestMessage<{NomeTabela}>" + Environment.NewLine);
            methodo.Append("            {" + Environment.NewLine);
            methodo.Append($"                Procedure = $\"{{PackageName}}.{{Procedures.MAG_SP_PDL_S_{nomeProcedure}}}\"," + Environment.NewLine);
            methodo.Append($"                MethodApi = GetClass.GetMethod()" + Environment.NewLine);
            methodo.Append("            };" + Environment.NewLine);
            methodo.Append(Environment.NewLine);
            methodo.Append("            BeginNewStatement(result.Procedure);" + Environment.NewLine);
            methodo.Append("            AddParameter(\"INTIDPROCESSO\", idProcesso);" + Environment.NewLine);
            methodo.Append(Environment.NewLine);
            methodo.Append("            OpenConnection();" + Environment.NewLine);
            methodo.Append("            using (var reader = ExecuteReader())" + Environment.NewLine);
            methodo.Append("            {" + Environment.NewLine);
            methodo.Append("                if (reader.Read())" + Environment.NewLine);
            methodo.Append($"               {{" + Environment.NewLine);
            methodo.Append($"                    result.Content = new {NomeTabela}" + Environment.NewLine);
            methodo.Append("                    {" + Environment.NewLine);
            methodo.Append(GetListaItensGetById());
            methodo.Append("                    };" + Environment.NewLine);
            methodo.Append("                return result;" + Environment.NewLine);
            methodo.Append($"               }}" + Environment.NewLine);
            methodo.Append("            }" + Environment.NewLine);
            methodo.Append(Environment.NewLine);
            methodo.Append("            result.Message = $\"A solicitação {idProcesso} não foi encontrada.\";" + Environment.NewLine);
            methodo.Append("            result.StatusCode = HttpStatusCode.NoContent;" + Environment.NewLine);
            methodo.Append($"            result.Content = new {NomeTabela}();" + Environment.NewLine);
            methodo.Append(Environment.NewLine);
            methodo.Append("            return result;" + Environment.NewLine);
            methodo.Append("       }" + Environment.NewLine);
            methodo.Append(Environment.NewLine);
            return methodo;
        }

        private StringBuilder GetListaItensGetById()
        {
            var atributoText = new StringBuilder();
            foreach (var item in ListaAtributosTabela)
            {
                atributoText.Append($"                        {item.COLUMN_NAME} = \"{item.COLUMN_NAME}\".GetValueOrDefault<{GetTypeAtribute(item.DATA_TYPE, item.NULLABLE)}>(reader)," + Environment.NewLine);
            }
            return atributoText;
        }
        #endregion

        #region ::: ADD :::
        private StringBuilder Add(string nomeProcedure)
        {
            var methodo = new StringBuilder();
            methodo.Append(Environment.NewLine);
            methodo.Append($"        public RequestMessage<string> Add({NomeTabela} entidade, bool commit = false)" + Environment.NewLine);
            methodo.Append("        {" + Environment.NewLine + Environment.NewLine);

            methodo.Append($"            BeginNewStatement(PackageName, Procedures.MAG_SP_PDL_I_{nomeProcedure});" + Environment.NewLine);

            methodo.Append(Environment.NewLine);
            methodo.Append("            AddResult();" + Environment.NewLine);
            methodo.Append(GetListaItensAdd());
            methodo.Append(Environment.NewLine + "            return RequestProc(GetClass.GetMethod(), commit);" + Environment.NewLine);
            methodo.Append("        }" + Environment.NewLine);
            methodo.Append(Environment.NewLine);
            return methodo;
        }

        private StringBuilder GetListaItensAdd()
        {
            var atributoText = new StringBuilder();
            foreach (var item in ListaAtributosTabela)
            {
                atributoText.Append($"            AddParameter(\"{item.COLUMN_NAME}\", entidade.{item.COLUMN_NAME});" + Environment.NewLine);
            }
            return atributoText;
        }

        #endregion

        #region ::: UPDATE :::
        private StringBuilder Update(string nomeProcedure)
        {
            var methodo = new StringBuilder();
            methodo.Append(Environment.NewLine);
            methodo.Append($"        public RequestMessage<string> Update({NomeTabela} entidade, bool commit = false)" + Environment.NewLine);
            methodo.Append("        {" + Environment.NewLine + Environment.NewLine);

            methodo.Append($"            BeginNewStatement(PackageName, Procedures.MAG_SP_PDL_U_{nomeProcedure});" + Environment.NewLine);

            methodo.Append(Environment.NewLine);
            methodo.Append("            AddResult();" + Environment.NewLine);
            methodo.Append(GetListaItensAdd());
            methodo.Append(Environment.NewLine + "            return RequestProc(GetClass.GetMethod(), commit);" + Environment.NewLine);
            methodo.Append("        }" + Environment.NewLine);
            methodo.Append(Environment.NewLine);
            return methodo;
        }

        #endregion

        #endregion

        public StringBuilder GerarInterfaceSharProc()
        {
            var nomeProcBase = NomeTabela.Replace("MAG_T_PDL", "").Replace("_", "");

            var classe = new StringBuilder();
            classe.Append("using System;" + Environment.NewLine + Environment.NewLine);
            classe.Append("namespace MapeadorDeEntidades.Form" + Environment.NewLine);
            classe.Append("{" + Environment.NewLine);
            classe.Append($"    public interface {nomeProcBase.ToLowerInvariant()}RequestRepository : IADORepository" + Environment.NewLine);
            classe.Append("    {" + Environment.NewLine + Environment.NewLine);
            classe.Append(GetInterfacesMethod());
            classe.Append("    }" + Environment.NewLine);
            classe.Append("}" + Environment.NewLine);

            return classe;
        }

        private StringBuilder GetInterfacesMethod()
        {
            var assinatura = new StringBuilder();
            assinatura.Append($"        RequestMessage<{NomeTabela}> GetById(long idProcesso);" + Environment.NewLine + Environment.NewLine);
            assinatura.Append($"        RequestMessage<string> Add({NomeTabela} entidade, bool commit = false);" + Environment.NewLine + Environment.NewLine);
            assinatura.Append($"        RequestMessage<string> Update({NomeTabela} entidade, bool commit = false);" + Environment.NewLine + Environment.NewLine);
            return assinatura;
        }
    }
}
