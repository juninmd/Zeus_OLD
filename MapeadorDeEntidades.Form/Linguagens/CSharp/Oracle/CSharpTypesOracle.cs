namespace MapeadorDeEntidades.Form.Linguagens.CSharp.Oracle
{
    public static class CSharpTypesOracle
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
