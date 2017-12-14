namespace Zeus.Linguagens.CSharp.MYSQL
{
    public static class CSharpTypesMySql
    {
        public static bool IsNullabe(string aceitaNull)
        {
            return aceitaNull == "Y";
        }
        public static string GetTypeAtribute(string tipoAttr, string aceitaNull)
        {
            switch (tipoAttr)
            {
                case "int":
                case "enum":
                    return "int" + (IsNullabe(aceitaNull) ? "?" : "");
                case "tinyint":
                    return "short" + (IsNullabe(aceitaNull) ? "?" : "");
                case "datetime":
                    return "DateTime" + (IsNullabe(aceitaNull) ? "?" : "");
                case "long":
                    return "long" + (IsNullabe(aceitaNull) ? "?" : "");
                default:
                    return "string";
            }
        }
    }
}
