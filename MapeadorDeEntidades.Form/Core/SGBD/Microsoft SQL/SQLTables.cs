using System.Collections.Generic;

namespace MapeadorDeEntidades.Form.Core.SGBD.Microsoft_SQL
{
    public class SQLTables : SQLRepository
    {
        public List<string> ListaTabelas()
        {
            var lista = new List<string>();
            return lista;
        }

        public List<SQLEntidadeTabela> ListarAtributos(string nomeTabela)
        {
            var lista = new List<SQLEntidadeTabela>();
            return lista;
        }
    }
}
