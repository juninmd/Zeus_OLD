using System.Collections.Generic;

namespace MapeadorDeEntidades.Form.Core.SGBD.Microsoft_SQL
{
    public class SQLTables : SQLRepository
    {
        public List<string> ListaTabelas()
        {
            BeginNewStatement("SELECT TABLE_NAME FROM information_schema.tables order by table_name");
            OpenConnection();

            var lista = new List<string>();

            using (var r = ExecuteReader())
                while (r.Read())
                {
                    lista.Add(r.GetValueOrDefault<string>("table_name"));
                };
            return lista;
        }

        public List<SQLEntidadeTabela> ListarAtributos(string nomeTabela)
        {
            var lista = new List<SQLEntidadeTabela>();
            return lista;
        }
    }
}
