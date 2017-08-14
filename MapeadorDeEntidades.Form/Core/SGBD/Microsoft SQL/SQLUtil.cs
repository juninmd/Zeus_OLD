using System.Linq;

namespace Zeus.Core.SGBD.Microsoft_SQL
{
    public static class SQLUtil
    {
        public static string TratarNomeSQL(this string nome)
        {
            return nome.Contains("[") ? nome.Split('.')[1].Replace("[", "").Replace("]", "") : nome;
        }
        public static string TratarNomeSQLDatabase()
        {
            return ParamtersInput.ConnectionString.Split(';')
                .Select(value => value.Split('='))
                .ToDictionary(pair => pair[0], pair => pair[1])["Database"];
        }
    }
}
