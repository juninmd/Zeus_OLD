namespace MapeadorDeEntidades.Form.Core
{
    public static class Tratamentos
    {
        public static string TratarNomeTabela(this string nome)
        {
            return nome.Replace("MAG_T", "").Replace("PDL", "").Replace("CA", "").Replace("_", "");
        }
        public static string TratarNomePackage(this string nome) { return nome.Replace("_T_", "_PG_"); }
    }
}
