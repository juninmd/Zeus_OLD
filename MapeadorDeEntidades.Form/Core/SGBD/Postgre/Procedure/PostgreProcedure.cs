using System;
using System.Collections.Generic;
using System.Text;
using Zeus.Core.SGBD.Postgre.Procedure.Verbos;
using Zeus.Linguagens.Base;
using Zeus.Properties;

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
            header.Append(new PostgreGet().Init($"{Settings.Default.PrefixoProcedure}S_{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new PostgreBuscar().Init($"{Settings.Default.PrefixoProcedure}S_{baseProc}_ID", NomeTabela, ListaAtributosTabela));
            header.Append(new PostgreInsert().Init($"{Settings.Default.PrefixoProcedure}I_{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new PostgreUpdate().Init($"{Settings.Default.PrefixoProcedure}U_{baseProc}", NomeTabela, ListaAtributosTabela));
            header.Append(new PostgreDelete().Init($"{Settings.Default.PrefixoProcedure}D_{baseProc}", NomeTabela, ListaAtributosTabela));
            return header.ToString();
        }
    }
}
