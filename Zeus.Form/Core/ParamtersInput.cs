﻿using System.Collections.Generic;

namespace Zeus.Core
{
    public static class ParamtersInput
    {
        public static Prefixos Prefixos { get; set; }

        /// <summary>
        ///     Caminho selecionado
        /// </summary>
        public static string SelectedPath { get; set; }

        public static List<string> NomeTabelas { get; set; }

        /// <summary>
        ///     1 - C#   |
        ///     2 - JAVA |
        ///     3 - Node |
        /// </summary>
        public static int Linguagem { get; set; }

        /// <summary>
        ///     É acesso via Procedure?
        /// </summary>
        public static bool Procedure { get; set; }

        /// <summary>
        ///     1 - Oracle        |
        ///     2 - Microsoft SQL |
        ///     3 - MYSQL         |
        ///     4 - Firebird      |
        ///     5 - Postgre       |
        /// </summary>
        public static int SGBD { get; set; }

        public static string ConnectionString { get; set; }

        /// <summary>
        ///     Schema escolhido
        /// </summary>
        public static string DataBase { get; set; }

        public static bool TodasTabelas { get; set; }

        public static bool UnificarOutput { get; set; }
    }

    public class Prefixos
    {
        public string Tabela { get; set; }
        public string Package { get; set; }
        public string Procedure { get; set; }
    }
}