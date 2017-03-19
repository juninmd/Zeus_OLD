namespace Zeus.Core.SGBD.Firebird
{
    public static class FirebirdUtil
    {
        public static string TratarNomeFirebird(this string nome)
        {
            return nome.Split('.')[1].Replace("[", "").Replace("]", ""); ;
        }
    }
}
