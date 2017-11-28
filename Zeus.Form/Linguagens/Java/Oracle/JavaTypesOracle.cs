using Zeus.Core.SGBD.Oracle;

namespace Zeus.Linguagens.Java.Oracle
{
    public static class JavaTypesOracle
    {
     
        public static string GetTypeAtribute(OracleEntidadeTabela prop)
        {
            switch (prop.DATA_TYPE)
            {
                case "DATE":
                    return "Date";
                case "NUMBER":
                    {
                        if (prop.DATA_PRECISION == null || prop.DATA_PRECISION <= 4)
                            return "Integer";
                        if (prop.DATA_PRECISION <= 15)
                            return "Long";
                        return "BigDecimal";
                    }

                default:
                    return "String";
            }
        }
    }
}
