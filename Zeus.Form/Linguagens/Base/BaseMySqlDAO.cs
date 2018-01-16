using System;
using System.Collections.Generic;
using System.Linq;
using Zeus.Core.SGBD.MySql;

namespace Zeus.Linguagens.Base
{
    public class BaseMySqlDAO
    {
        public BaseMySqlDAO(string nomeTabela)
        {
            NomeTabela = nomeTabela;
        }

        protected static string N => Environment.NewLine;
        public string NomeTabela { get; set; }
        public List<MySqlEntidadeTabela> ListaAtributosTabela => new MySqlTables().ListarAtributos(NomeTabela);

        protected string parametrosQuery(bool full)
        {
            if (full == false)
            {
                var semit = ListaAtributosTabela.Where(x => x.COLUMN_NAME != ListaAtributosTabela.First().COLUMN_NAME);
                return "{ " + string.Join(", ", semit.Select(e => e.COLUMN_NAME + ": " + "body." + e.COLUMN_NAME)) +
                       " }";
            }

            return "{ " + string.Join(", ",
                       ListaAtributosTabela.Select(e => e.COLUMN_NAME + ": " + "body." + e.COLUMN_NAME)) + " }";
        }
    }
}