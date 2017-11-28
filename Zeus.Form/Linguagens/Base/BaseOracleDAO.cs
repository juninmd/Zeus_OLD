using System;
using System.Collections.Generic;
using Zeus.Core.SGBD.Oracle;

namespace Zeus.Linguagens.Base
{
    public class BaseOracleDAO
    {
        protected static string N => Environment.NewLine;
        public BaseOracleDAO(string nomeTabela)
        {
            NomeTabela = nomeTabela;
        }
        public string NomeTabela { get; set; }
        public List<OracleEntidadeTabela> ListaAtributosTabela => new OracleTables().ListarAtributos(NomeTabela);
    }
}
