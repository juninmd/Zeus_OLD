using System.Text;
using Zeus.Core.SGBD.MySql.Procedure.Verbos;
using Zeus.Linguagens.Base;

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
            header.Append(new MySqlGet().Init($"{ParamtersInput.Prefixos.Procedure}S_{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new MySqlBuscar().Init($"{ParamtersInput.Prefixos.Procedure}S_{baseProc}_ID", NomeTabela, ListaAtributosTabela));
            header.Append(new MySqlInsert().Init($"{ParamtersInput.Prefixos.Procedure}I_{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new MySqlUpdate().Init($"{ParamtersInput.Prefixos.Procedure}U_{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new MySqlDelete().Init($"{ParamtersInput.Prefixos.Procedure}D_{baseProc}", NomeTabela, ListaAtributosTabela));
            return header.ToString();
        }
    }
}
