namespace Zeus.Core.SGBD.MySql
{
    public static class MySqlUtil
    {
        public static string TratarNomeMySql(this string nome)
        {
            return nome.Split('.')[1].Replace("[", "").Replace("]", ""); ;
        }
    }
}
