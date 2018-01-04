using Zeus.Core.SGBD.Postgre;

namespace Zeus.Linguagens.Java.Postgre
{
    public static class JavaTypesPostgre
    {
        public static string GetTypeAtribute(PostgreEntidadeTabela prop)
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