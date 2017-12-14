using System.Text;
using Zeus.Core.SGBD.Postgre.Procedure.Verbos;
using Zeus.Linguagens.Base;

namespace Zeus.Core.SGBD.Postgre.Procedure
{
    public class PostgreProcedure : BasePostgreDAO
    {
        public PostgreProcedure(string nomeTabela) : base(nomeTabela)
        {
        }

        public string GerarBody()
        {
            var baseProc = NomeTabela.TratarNomeTabela().ToUpper();
            var header = new StringBuilder();
            header.Append(new PostgreGet().Init($"{ParamtersInput.Prefixos.Procedure}S_{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new PostgreBuscar().Init($"{ParamtersInput.Prefixos.Procedure}S_{baseProc}_ID", NomeTabela, ListaAtributosTabela));
            header.Append(new PostgreInsert().Init($"{ParamtersInput.Prefixos.Procedure}I_{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new PostgreUpdate().Init($"{ParamtersInput.Prefixos.Procedure}U_{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new PostgreDelete().Init($"{ParamtersInput.Prefixos.Procedure}D_{baseProc}", NomeTabela, ListaAtributosTabela));
            return header.ToString();
        }
    }
}
