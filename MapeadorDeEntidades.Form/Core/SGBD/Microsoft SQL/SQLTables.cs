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
            BeginNewStatement("use apolo;" +
            "SELECT OBJECT_SCHEMA_NAME(T.[object_id]," +
            " DB_ID()) AS[Schema], " +
            "AC.[name] AS[column_name], " +
            "TY.[name] AS DATA_TYPE, " +
            "AC.[max_length] AS CHAR_LENGTH, " +
            "AC.[precision] AS DATA_PRECISION, " +
            "AC.[scale] AS DATA_SCALE, " +
            "AC.[is_nullable] AS NULLABLE " +
            "FROM sys.[tables] AS T " +
            "INNER JOIN sys.[all_columns] AC ON " +
            "T.[object_id] = AC.[object_id] " +
            "INNER JOIN sys.[types] TY ON " +
            "AC.[system_type_id] = TY.[system_type_id] AND " +
            "AC.[user_type_id] = TY.[user_type_id] " +
            "WHERE T.[is_ms_shipped] = 0 " +
            "AND T.[is_ms_shipped] = 0 " +
            $"AND T.[name] = '{nomeTabela}' " +
            "ORDER BY T.[name], AC.[column_id]");

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
