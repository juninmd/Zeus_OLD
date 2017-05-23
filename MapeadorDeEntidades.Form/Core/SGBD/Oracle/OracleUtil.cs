namespace Zeus.Core.SGBD.Oracle
{
    public static class OracleUtil
    {
        public static string TratarNomeSequence(this string nome)
        {
            return "SQ_" + nome.TratarNomeTabela() + ".NEXTVAL";
        }
    }
}
