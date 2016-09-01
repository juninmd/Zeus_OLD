namespace MapeadorDeEntidades.Form.Core
{
    public static class Tratamentos
    {
        public static string TratarNomeTabela(this string nome)
        {
            return nome.Replace("MAG_T", "").Replace("_PDL_", "").Replace("_CA_", "");
        }
        public static string TratarNomePackage(this string nome) { return nome.Replace("_T_", "_PG_"); }
    }
}
