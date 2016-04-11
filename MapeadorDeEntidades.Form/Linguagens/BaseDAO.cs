using System;
using System.Collections.Generic;

namespace MapeadorDeEntidades.Form.Linguagens
{
    public class BaseDAO
    {
        protected static string N => Environment.NewLine;
        public BaseDAO(string nomeTabela)
        {
            NomeTabela = nomeTabela;
        }
        public string NomeTabela { get; set; }
        public List<EntidadeTabela> ListaAtributosTabela => new OracleTables().ListarAtributos(NomeTabela);
    }
}
