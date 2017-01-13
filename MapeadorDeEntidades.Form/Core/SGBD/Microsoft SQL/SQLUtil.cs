namespace Zeus.Core.SGBD.Microsoft_SQL
{
    public static class SQLUtil
    {
        public static string TratarNomeSQL(this string nome)
        {
            return nome.Split('.')[1].Replace("[", "").Replace("]", ""); ;
        }
    }
}
