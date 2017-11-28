using System.Text;
using Zeus.Core.SGBD.Microsoft_SQL.Procedure.Verbos;
using Zeus.Linguagens.Base;

namespace Zeus.Core.SGBD.Microsoft_SQL.Procedure
{
    public class SQLProcedure : BaseSQLDAO
    {
        public SQLProcedure(string nomeTabela) : base(nomeTabela)
        {
        }

        public string GerarBody()
        {
            var header = new StringBuilder();
            header.Append(new SQLGet().Init($"Sel{NomeTabela}", NomeTabela, ListaAtributosTabela));
            header.Append(new SQLBuscar().Init($"Busca{NomeTabela}", NomeTabela, ListaAtributosTabela));
            header.Append(new SQLInsert().Init($"Ins{NomeTabela}", NomeTabela, ListaAtributosTabela));
            header.Append(new SQLUpdate().Init($"Upd{NomeTabela}", NomeTabela, ListaAtributosTabela));
            header.Append(new SQLDelete().Init($"Delete{NomeTabela}", NomeTabela, ListaAtributosTabela));
            return header.ToString();
        }

      
    }
}
