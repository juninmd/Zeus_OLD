using System;
using System.Collections.Generic;
using System.Text;
using MapeadorDeEntidades.Form.Core.SGBD.MySql;
using MapeadorDeEntidades.Form.Core.SGBD.MYSQL.Procedure.Verbos;

namespace MapeadorDeEntidades.Form.Core.SGBD.MYSQL.Procedure
{
    public class MySqlProcedure
    {
        private string N => Environment.NewLine;

        public string NomeTabela { get; set; }

        public List<MySqlEntidadeTabela> ListaAtributosTabela { get; set; }

        public MySqlProcedure(string nomeTabela, List<MySqlEntidadeTabela> atributosTabela)
        {
            NomeTabela = nomeTabela;
            ListaAtributosTabela = atributosTabela;
        }

        public StringBuilder GerarPackageBody()
        {
            var baseProc = NomeTabela.TratarNomeMySql();
            var header = new StringBuilder();
            header.Append(new MySqlGet().Init($"Sel{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new MySqlBuscar().Init($"Busca{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new MySqlInsert().Init($"Ins{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new MySqlUpdate().Init($"Upd{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new MySqlDelete().Init($"Delete{baseProc}", NomeTabela, ListaAtributosTabela));
            return header;
        }

    }
}
