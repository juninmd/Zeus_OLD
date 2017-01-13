using System.Collections.Generic;

namespace Zeus.Core.SGBD.Microsoft_SQL
{
    public class SQLTables : SQLRepository
    {
        public List<string> ListaTabelas()
        {
            BeginNewStatement("SELECT TABLE_NAME, TABLE_SCHEMA FROM information_schema.tables WHERE TABLE_TYPE = 'BASE TABLE' order by table_name");
            OpenConnection();

            var lista = new List<string>();

            using (var r = ExecuteReader())
                while (r.Read())
                {
                    lista.Add($"[{r.GetValueOrDefault<string>("TABLE_SCHEMA")}].[{r.GetValueOrDefault<string>("TABLE_NAME")}]");
                };
            return lista;
        }

        public List<SQLEntidadeTabela> ListarAtributos(string nomeTabela)
        {
            BeginNewStatement("select * from information_schema.columns " +
                              "where table_schema = 'fatecjava' " +
                              $"and TABLE_NAME = '{nomeTabela}'" +
                              "order by table_name, ordinal_position");

            OpenConnection();

            var lista = new List<SQLEntidadeTabela>();

            using (var r = ExecuteReader())
                while (r.Read())
                {
                    lista.Add(new SQLEntidadeTabela
                    {
                        COLUMN_NAME = r.GetValueOrDefault<string>("COLUMN_NAME"),
                        DATA_TYPE = r.GetValueOrDefault<string>("DATA_TYPE"),
                        CHAR_LENGTH = r.GetValueOrDefault<short>("CHAR_LENGTH"),
                        DATA_PRECISION = r.GetValueOrDefault<byte?>("DATA_PRECISION"),
                        DATA_SCALE = r.GetValueOrDefault<byte?>("DATA_SCALE"),
                        NULLABLE = r.GetValueOrDefault<bool>("NULLABLE"),
                        COMMENTS = "",
                    });
                };

            return lista;
        }
    }
}
