﻿using Zeus.Core.SGBD.MySql;

namespace Zeus.Linguagens.Java.MySql
{
    public static class JavaTypesMySql
    {
        public static string GetTypeAtribute(MySqlEntidadeTabela prop)
        {
            switch (prop.DATA_TYPE)
            {
                case "date":
                    return "Date";
                case "int":
                {
                    if (prop.NUMERIC_PRECISION <= 4)
                        return prop.IS_NULLABLE == "Y" ? "Integer" : "int";
                    if (prop.NUMERIC_PRECISION <= 15)
                        return prop.IS_NULLABLE == "Y" ? "Long" : "long";
                    return "int";
                }

                default:
                    return "String";
            }
        }
    }
}