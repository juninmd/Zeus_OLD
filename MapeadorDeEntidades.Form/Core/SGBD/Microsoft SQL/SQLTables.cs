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
            BeginNewStatement($"use {SQLUtil.TratarNomeSQLDatabase()};" +
                              "select * from information_schema.columns " +
                              $"where TABLE_CATALOG = '{SQLUtil.TratarNomeSQLDatabase()}' " +
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
                        CHARACTER_MAXIMUM_LENGTH = r.GetValueOrDefault<int>("CHARACTER_MAXIMUM_LENGTH"),
                        NUMERIC_PRECISION = r.GetValueOrDefault<byte?>("NUMERIC_PRECISION"),
                        NUMERIC_SCALE = r.GetValueOrDefault<int?>("NUMERIC_SCALE"),
                        IS_NULLABLE = r.GetValueOrDefault<string>("IS_NULLABLE") == "YES",
                        COMMENTS = "",
                    });
                };

            return lista;
        }
    }
}
