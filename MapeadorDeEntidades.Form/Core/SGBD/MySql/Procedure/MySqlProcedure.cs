using System.Text;
using Zeus.Core.SGBD.MySql.Procedure.Verbos;
using Zeus.Linguagens.Base;
using Zeus.Properties;

namespace Zeus.Core.SGBD.MySql.Procedure
{
    public class MySqlProcedure : BaseMySqlDAO
    {
        public MySqlProcedure(string nomeTabela) : base(nomeTabela)
        {
        }

        public string GerarBody()
        {
            var baseProc = NomeTabela.TratarNomeTabela().ToUpper();
            var header = new StringBuilder();
            header.Append(new MySqlGet().Init($"{Settings.Default.PrefixoProcedure}S_{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new MySqlBuscar().Init($"{Settings.Default.PrefixoProcedure}S_{baseProc}_ID", NomeTabela, ListaAtributosTabela));
            header.Append(new MySqlInsert().Init($"{Settings.Default.PrefixoProcedure}I_{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new MySqlUpdate().Init($"{Settings.Default.PrefixoProcedure}U_{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new MySqlDelete().Init($"{Settings.Default.PrefixoProcedure}D_{baseProc}", NomeTabela, ListaAtributosTabela));
            return header.ToString();
        }
    }
}
