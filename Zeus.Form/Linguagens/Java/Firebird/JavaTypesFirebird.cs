using Zeus.Core.SGBD.Firebird;

namespace Zeus.Linguagens.Java.Firebird
{
    public static class JavaTypesFirebird
    {
        public static string GetTypeAtribute(FirebirdEntidadeTabela prop)
        {
            switch (prop.FIELD_NAME)
            {
                case "date":
                    return "Date";
                case "int":
                {
                    return "int";
                }

                default:
                    return "String";
            }
        }
    }
}