using System.Collections.Generic;

namespace Zeus.Core.SGBD.Firebird
{
    public class FirebirdTables : FirebirdRepository
    {
        public List<string> ListaTabelas()
        {
            var lista = new List<string>();
            var query = $"select rdb$relation_name as TABLE_NAME" +
                        $" from rdb$relations where rdb$view_blr is null and(rdb$system_flag is null or rdb$system_flag = 0)" +
                        $"ORDER BY TABLE_NAME";

            using (var r = ExecuteReader(query))
            {
                while (r.Read())
                    lista.Add(r.GetValueOrDefault<string>("TABLE_NAME").Trim());
            }

            ;
            CloseConnection();
            return lista;
        }

        public List<FirebirdEntidadeTabela> ListarAtributos(string nomeTabela)
        {
            var lista = new List<FirebirdEntidadeTabela>();
            var sql = $"SELECT * FROM RDB$RELATION_FIELDS WHERE RDB$RELATION_NAME = '{nomeTabela}'";

            using (var r = ExecuteReader(sql))
            {
                while (r.Read())
                    lista.Add(new FirebirdEntidadeTabela
                    {
                        FIELD_NAME = r.GetValueOrDefault<string>("RDB$FIELD_NAME").Trim(),
                        IS_NULLABLE = r.GetValueOrDefault<string>("RDB$NULL_FLAG") != "1"
                    });
            }

            ;
            CloseConnection();

            return lista;
        }
    }
}