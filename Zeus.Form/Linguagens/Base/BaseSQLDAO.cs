using System;
using System.Collections.Generic;
using Zeus.Core.SGBD.Microsoft_SQL;

namespace Zeus.Linguagens.Base
{
    public class BaseSQLDAO
    {
        public BaseSQLDAO(string nomeTabela)
        {
            NomeTabela = nomeTabela.TratarNomeSQL();
        }

        protected static string N => Environment.NewLine;
        public string NomeTabela { get; set; }
        public List<SQLEntidadeTabela> ListaAtributosTabela => new SQLTables().ListarAtributos(NomeTabela);
    }
}