using System.Collections.Generic;
using MapeadorDeEntidades.Form.Core.SGBD.Microsoft_SQL;

namespace MapeadorDeEntidades.Form.Core.SGBD.MySql
{
    public class MySqlTables : MySqlRepository
    {
        public List<string> ListaTabelas()
        {
            BeginNewStatement("select * from information_schema.tables where table_schema = \"fatecjava\" order by table_name");
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
            BeginNewStatement("SELECT OBJECT_SCHEMA_NAME(T.[object_id]," +
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
            $"AND '['+OBJECT_SCHEMA_NAME(T.[object_id], DB_ID())+']'+'.['+ T.[name]+']' = '{nomeTabela}' " +
            "ORDER BY T.[name], AC.[column_id]");

            OpenConnection();

            var lista = new List<SQLEntidadeTabela>();

            using (var r = ExecuteReader())
                while (r.Read())
                {
                    lista.Add(new SQLEntidadeTabela
                    {
                        COLUMN_NAME = NullSafeGetter.GetValueOrDefault<string>(r, "COLUMN_NAME"),
                        DATA_TYPE = NullSafeGetter.GetValueOrDefault<string>(r, "DATA_TYPE"),
                        CHAR_LENGTH = NullSafeGetter.GetValueOrDefault<short>(r, "CHAR_LENGTH"),
                        DATA_PRECISION = NullSafeGetter.GetValueOrDefault<byte?>(r, "DATA_PRECISION"),
                        DATA_SCALE = NullSafeGetter.GetValueOrDefault<byte?>(r, "DATA_SCALE"),
                        NULLABLE = NullSafeGetter.GetValueOrDefault<bool>(r, "NULLABLE"),
                        COMMENTS = "",
                    });
                };

            return lista;
        }
    }
}
