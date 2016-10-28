namespace MapeadorDeEntidades.Form.Core
{
    public static class Tratamentos
    {
        public static string TratarNomeTabela(this string nome)
        {
            return nome.Replace("MAG_T", "").Replace("_PDL_", "").Replace("_CA_", "");
        }
        public static string TratarNomePackage(this string nome) { return nome.Replace("_T_", "_PG_"); }
        public static string TratarNomeBase(this string nome) { return $"\"{nome.Split(';')[1].Split('=')[1]}\""; }

        public static string TratarNomeSequence(this string nome)
        {
            return nome.Replace("_T_", "_SEQ_") + ".NEXTVAL";
        }
    }
}
