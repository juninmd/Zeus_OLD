namespace Zeus.Linguagens.CSharp.Firebird
{
    public static class CSharpTypesFirebird
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
