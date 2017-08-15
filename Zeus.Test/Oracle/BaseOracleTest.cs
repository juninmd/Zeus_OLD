using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Zeus.Core;

namespace Zeus.Test.Oracle
{
    public class BaseOracleTest
    {
        public BaseOracleTest()
        {
            ParamtersInput.ConnectionString = ConfigurationManager.AppSettings["oracleConnect"];
            ParamtersInput.NomeTabelas = new List<string> { "teste" };
            ParamtersInput.SelectedPath = Directory.GetCurrentDirectory() + "\\Test\\";
            ParamtersInput.SGBD = 1;

            if (!Directory.Exists(ParamtersInput.SelectedPath))
                Directory.CreateDirectory(ParamtersInput.SelectedPath);
        }
    }
}
