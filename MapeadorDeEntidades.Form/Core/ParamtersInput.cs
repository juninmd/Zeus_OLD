using System.Collections.Generic;

namespace Zeus.Core
{
    public static class ParamtersInput
    {
        public static List<string> NomeTabelas { get; set; }

        /// <summary>
        /// 1 - C#
        /// 2 - JAVA
        /// 3 - Node
        /// </summary>
        public static int Linguagem { get; set; }

        /// <summary>
        /// 1 - Oracle
        /// 2 - Microsoft SQL
        /// 3 - MYSQL
        /// </summary>
        public static int SGBD { get; set; }
        public static string ConnectionString { get; set; }

        /// <summary>
        /// Schema escolhido
        /// </summary>
        public static string DataBase { get; set; }

        public static bool TodasTabelas { get; set; }
    }
}
