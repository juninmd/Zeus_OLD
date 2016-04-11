namespace MapeadorDeEntidades.Form
{
    public static class OracleAtributtes
    {
        public static string IsNullabe(string aceitaNull)
        {
            return aceitaNull == "Y" ? "?" : "";
        }
        public static string GetTypeAtribute(this string tipoOracle, string aceitaNull)
        {
            switch (tipoOracle)
            {
                case "DATE":
                    return "DateTime" + IsNullabe(aceitaNull);
                case "NUMBER":
                    return "long" + IsNullabe(aceitaNull);
                default:
                    return "string";
            }
        }
    }
}
