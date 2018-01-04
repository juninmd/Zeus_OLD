namespace Zeus.Linguagens.CSharp.Postgre
{
    public static class CSharpTypesPostgre
    {
        public static bool IsNullabe(string aceitaNull)
        {
            return aceitaNull == "Y";
        }

        public static string GetTypeAtribute(string tipoAttr, string aceitaNull)
        {
            switch (tipoAttr)
            {
                case "DATE":
                    return "DateTime" + (IsNullabe(aceitaNull) ? "?" : "");
                case "NUMBER":
                    return "long" + (IsNullabe(aceitaNull) ? "?" : "");
                default:
                    return "string";
            }
        }
    }
}