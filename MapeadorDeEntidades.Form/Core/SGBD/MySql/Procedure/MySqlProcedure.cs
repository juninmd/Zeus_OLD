using System;
using System.Collections.Generic;
using System.Text;
using MapeadorDeEntidades.Form.Core.SGBD.MySql;
using MapeadorDeEntidades.Form.Core.SGBD.MYSQL.Procedure.Verbos;
using MapeadorDeEntidades.Form.Properties;

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
            var baseProc = NomeTabela.TratarNomeTabela().ToUpper();
            var header = new StringBuilder();
            header.Append(new MySqlGet().Init($"{Settings.Default.PrefixoProcedure}S_{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new MySqlBuscar().Init($"{Settings.Default.PrefixoProcedure}S_{baseProc}_ID", NomeTabela, ListaAtributosTabela));
            header.Append(new MySqlInsert().Init($"{Settings.Default.PrefixoProcedure}I_{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new MySqlUpdate().Init($"{Settings.Default.PrefixoProcedure}U_{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new MySqlDelete().Init($"{Settings.Default.PrefixoProcedure}D_{baseProc}", NomeTabela, ListaAtributosTabela));
            return header;
        }

    }
}
