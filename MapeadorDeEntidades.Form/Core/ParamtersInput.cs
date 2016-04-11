namespace MapeadorDeEntidades.Form.Core
{
    public static class ParamtersInput
    {
        public static string NomeTabela { get; set; }

        /// <summary>
        /// 1 - C#
        /// 2 - JAVA
        /// 3 - JAVASCRIPT
        /// </summary>
        public static int Linguagem { get; set; }

        /// <summary>
        /// 1 - Oracle
        /// 2 - Microsoft SQL
        /// 3 - MYSQL
        /// </summary>
        public static int SGBD { get; set; }
        public static string ConnectionString { get; set; }
    }
}
