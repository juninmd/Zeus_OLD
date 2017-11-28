namespace Zeus.Linguagens.CSharp.SQL
{
    public static class CSharpTypesSQL
    {
        public static string GetTypeAtribute(string tipoAttr, bool aceitaNull)
        {
            switch (tipoAttr)
            {
                case "int":
                    return "int" + ((aceitaNull) ? "?" : "");
                case "datetime":
                    return "DateTime" + ((aceitaNull) ? "?" : "");
                case "NUMBER":
                    return "long" + ((aceitaNull) ? "?" : "");
                default:
                    return "string";
            }
        }
    }
}
