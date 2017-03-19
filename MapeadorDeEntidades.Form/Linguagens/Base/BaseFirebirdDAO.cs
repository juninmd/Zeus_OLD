using System;
using System.Collections.Generic;
using Zeus.Core.SGBD.Firebird;

namespace Zeus.Linguagens.Base
{
    public class BaseFirebirdDAO
    {
        protected static string N => Environment.NewLine;
        public BaseFirebirdDAO(string nomeTabela)
        {
            NomeTabela = nomeTabela;
        }
        public string NomeTabela { get; set; }
        public List<FirebirdEntidadeTabela> ListaAtributosTabela => new FirebirdTables().ListarAtributos(NomeTabela);
    }
}
