using Zeus.Core.SGBD.Microsoft_SQL;

namespace Zeus.Linguagens.Java.SQL
{
    public static class JavaTypesSQL
    {
        public static string GetTypeAtribute(SQLEntidadeTabela prop)
        {
            switch (prop.DATA_TYPE)
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