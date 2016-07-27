using MapeadorDeEntidades.Form.Core.SGBD.Oracle;

namespace MapeadorDeEntidades.Form.Linguagens.Java.Oracle
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
                        {
                            return (prop.NULLABLE == "Y") ? "Integer" : "int";
                        }
                        else if (prop.DATA_PRECISION <= 15)
                        {
                            return (prop.NULLABLE == "Y") ? "Long" : "long";
                        }
                        return "BigDecimal";
                    }

                default:
                    return "String";
            }
        }
    }
}
