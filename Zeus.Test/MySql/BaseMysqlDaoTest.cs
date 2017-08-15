using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Zeus.Core;

namespace Zeus.Test.MySql
{
    public class BaseMysqlDaoTest
    {
        public BaseMysqlDaoTest()
        {
            ParamtersInput.ConnectionString = ConfigurationManager.AppSettings["mysqlConnect"];
            ParamtersInput.DataBase = ConfigurationManager.AppSettings["mysqlSchema"];

            ParamtersInput.NomeTabelas = new List<string> { "teste" };
            ParamtersInput.Procedure = false;
            ParamtersInput.SelectedPath = Directory.GetCurrentDirectory() + "\\Test\\";
            ParamtersInput.SGBD = 3;

            if (!Directory.Exists(ParamtersInput.SelectedPath))
                Directory.CreateDirectory(ParamtersInput.SelectedPath);
        }
    }
}
