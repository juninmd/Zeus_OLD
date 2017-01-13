using System;
using System.Collections.Generic;
using System.Text;
using Zeus.Core.SGBD.Microsoft_SQL.Procedure.Verbos;

namespace Zeus.Core.SGBD.Microsoft_SQL.Procedure
{
    public class SQLProcedure
    {
        private string N => Environment.NewLine;

        public string NomeTabela { get; set; }

        public List<SQLEntidadeTabela> ListaAtributosTabela { get; set; }

        public SQLProcedure(string nomeTabela, List<SQLEntidadeTabela> atributosTabela)
        {
            NomeTabela = nomeTabela;
            ListaAtributosTabela = atributosTabela;
        }

        public StringBuilder GerarPackageBody()
        {
            var baseProc = NomeTabela.TratarNomeSQL();
            var header = new StringBuilder();
            header.Append(new SQLGet().Init($"Sel{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new SQLBuscar().Init($"Busca{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new SQLInsert().Init($"Ins{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new SQLUpdate().Init($"Upd{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new SQLDelete().Init($"Delete{baseProc}", NomeTabela, ListaAtributosTabela));
            return header;
        }

    }
}
