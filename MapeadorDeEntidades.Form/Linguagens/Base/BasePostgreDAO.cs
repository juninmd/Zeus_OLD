using System;
using System.Collections.Generic;
using Zeus.Core.SGBD.Microsoft_SQL;
using Zeus.Core.SGBD.Postgre;

namespace Zeus.Linguagens.Base
{
    public class BasePostgreDAO
    {
        protected static string N => Environment.NewLine;
        public BasePostgreDAO(string nomeTabela)
        {
            NomeTabela = nomeTabela;
        }
        public string NomeTabela { get; set; }
        public List<PostgreEntidadeTabela> ListaAtributosTabela => new PostgreTables().ListarAtributos(NomeTabela);
    }
}
