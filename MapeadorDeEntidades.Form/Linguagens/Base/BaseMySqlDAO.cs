using System;
using System.Collections.Generic;
using MapeadorDeEntidades.Form.Core.SGBD.MySql;

namespace MapeadorDeEntidades.Form.Linguagens.Base
{
    public class BaseMySqlDAO
    {
        protected static string N => Environment.NewLine;
        public BaseMySqlDAO(string nomeTabela)
        {
            NomeTabela = nomeTabela;
        }
        public string NomeTabela { get; set; }
        public List<MySqlEntidadeTabela> ListaAtributosTabela => new MySqlTables().ListarAtributos(NomeTabela);
    }
}
