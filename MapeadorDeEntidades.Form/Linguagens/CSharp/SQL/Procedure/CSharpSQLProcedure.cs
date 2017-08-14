using System.Text;
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
            classe.Append("namespace MapeadorDeEntidades.Form" + N);
            classe.Append("{" + N);
            classe.Append($"    public class {nomeProcBase}RequestRepository : ADORepository" + N);
            classe.Append("    {" + N + N);
            classe.Append($"        private const string PackageName = \"Package{nomeProcBase}\";" + N + N);
            classe.Append(Procedures(nomeProcBase));
            classe.Append(new CSharpProcGetAllSQL().Init($"Sel{nomeProcBase}", nomeProcBase, ListaAtributosTabela));
            classe.Append(new CSharpProcGetByIdSQL().Init($"Busca{nomeProcBase}", nomeProcBase, ListaAtributosTabela));
            classe.Append(new CSharpProcPostSQL().Init($"Ins{nomeProcBase}", nomeProcBase, ListaAtributosTabela));
            classe.Append(new CSharpProcPutSQL().Init($"Upd{nomeProcBase}", nomeProcBase, ListaAtributosTabela));
            classe.Append(new CSharpProcDeleteSQL().Init($"Delete{nomeProcBase}", nomeProcBase, ListaAtributosTabela));
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
            proc.Append($"            Sel{nomeProcBase}," + N);
            proc.Append($"            Busca{nomeProcBase}," + N);
            proc.Append($"            Ins{nomeProcBase}," + N);
            proc.Append($"            Upd{nomeProcBase}" + N);
            proc.Append($"            Delete{nomeProcBase}" + N);
            proc.Append("        }" + N + N);
            return proc;
        }

        #endregion


        public StringBuilder GerarInterfaceSharProc()
        {
            var nomeProcBase = NomeTabela;

            var classe = new StringBuilder();
            classe.Append("using System;" + N + N);
            classe.Append("namespace MapeadorDeEntidades.Form" + N);
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
            assinatura.Append($"        RequestMessage<string> Add({NomeTabela} entidade, bool commit = false);" + N + N);
            assinatura.Append($"        RequestMessage<string> Update({NomeTabela} entidade, bool commit = false);" + N + N);
            assinatura.Append($"        RequestMessage<string> Delete(long id, bool commit = false);" + N + N);
            return assinatura;
        }
    }
}
