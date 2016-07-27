using System.Text;
using MapeadorDeEntidades.Form.Linguagens.Base;

namespace MapeadorDeEntidades.Form.Linguagens.CSharp.SQL.Procedure
{
    public class CSharpProcSQL : BaseSQLDAO
    {
        public CSharpProcSQL(string nomeTabela) : base(nomeTabela)
        {
        }

        #region CLASSE 

        public StringBuilder GerarBodyCSharpProc()
        {
            var nomeProcBase = NomeTabela.Replace("_", "").ToLowerInvariant();

            var classe = new StringBuilder();
            classe.Append("using System.Net;" + N);
            classe.Append("using PagamentoDespesasLojas.Domain.Helpers;" + N);
            classe.Append("using PagamentoDespesasLojas.Infra.Data;" + N);
            classe.Append("using System;" + N + N);
            classe.Append("namespace MapeadorDeEntidades.Form" + N);
            classe.Append("{" + N);
            classe.Append($"    public class {nomeProcBase}RequestRepository : ADORepository" + N);
            classe.Append("    {" + N + N);
            classe.Append($"        private const string PackageName = \"Package{nomeProcBase}\";" + N + N);
            classe.Append(Procedures(nomeProcBase));
            classe.Append(new CSharpProcGetAllSQL().Init($"Sel{nomeProcBase}", NomeTabela, ListaAtributosTabela));
            classe.Append(new CSharpProcGetByIdSQL().Init($"Busca{nomeProcBase}", NomeTabela, ListaAtributosTabela));
            classe.Append(new CSharpProcPostSQL().Init($"Ins{nomeProcBase}", NomeTabela, ListaAtributosTabela));
            classe.Append(new CSharpProcPutSQL().Init($"Upd{nomeProcBase}", NomeTabela, ListaAtributosTabela));
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
            proc.Append("        }" + N + N);
            return proc;
        }

        #endregion


        public StringBuilder GerarInterfaceSharProc()
        {
            var nomeProcBase = NomeTabela.Replace("_", "").ToLowerInvariant();

            var classe = new StringBuilder();
            classe.Append("using System;" + N + N);
            classe.Append("namespace MapeadorDeEntidades.Form" + N);
            classe.Append("{" + N);
            classe.Append($"    public interface {nomeProcBase.ToLowerInvariant()}Repository : IADORepository" + N);
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
            assinatura.Append($"        RequestMessage<List<{NomeTabela}>> GetAll();" + N + N);
            assinatura.Append($"        RequestMessage<string> Add({NomeTabela} entidade, bool commit = false);" + N + N);
            assinatura.Append($"        RequestMessage<string> Update({NomeTabela} entidade, bool commit = false);" + N + N);
            return assinatura;
        }
    }
}
