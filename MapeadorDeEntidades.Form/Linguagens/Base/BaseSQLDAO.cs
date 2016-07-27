using System;
using System.Collections.Generic;
using MapeadorDeEntidades.Form.Core.SGBD.Oracle;

namespace MapeadorDeEntidades.Form.Linguagens.Base
{
    public class BaseSQLDAO
    {
        protected static string N => Environment.NewLine;
        public BaseSQLDAO(string nomeTabela)
        {
            NomeTabela = nomeTabela;
        }
        public string NomeTabela { get; set; }
        public List<OracleEntidadeTabela> ListaAtributosTabela => new OracleTables().ListarAtributos(NomeTabela);
    }
}
