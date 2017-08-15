using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Zeus.Core;

namespace Zeus.Test.MySql
{
    public class BaseMysqlTest
    {
        public BaseMysqlTest()
        {
            ParamtersInput.ConnectionString = ConfigurationManager.AppSettings["mysqlConnect"];
            ParamtersInput.DataBase = ConfigurationManager.AppSettings["mysqlSchema"];

            ParamtersInput.NomeTabelas = new List<string> { "teste" };
            ParamtersInput.SelectedPath = Directory.GetCurrentDirectory() + "\\Test\\";
            ParamtersInput.SGBD = 3;

            if (!Directory.Exists(ParamtersInput.SelectedPath))
                Directory.CreateDirectory(ParamtersInput.SelectedPath);
        }
    }
}
