using System;
using System.Collections.Generic;
using Zeus.Core.SGBD.Postgre;

namespace Zeus.Linguagens.Base
{
    public class BasePostgreDAO
    {
        public BasePostgreDAO(string nomeTabela)
        {
            NomeTabela = nomeTabela;
        }

        protected static string N => Environment.NewLine;
        public string NomeTabela { get; set; }
        public List<PostgreEntidadeTabela> ListaAtributosTabela => new PostgreTables().ListarAtributos(NomeTabela);
    }
}