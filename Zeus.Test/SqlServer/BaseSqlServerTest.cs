using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Zeus.Core;

namespace Zeus.Test.SqlServer
{
    public class BaseSqlServerTest
    {
        public BaseSqlServerTest()
        {
            ParamtersInput.ConnectionString = ConfigurationManager.AppSettings["sqlserverConnect"];
            ParamtersInput.NomeTabelas = new List<string> { "teste" };
            ParamtersInput.SelectedPath = Directory.GetCurrentDirectory() + "\\Test\\";
            ParamtersInput.SGBD = 2;

            if (!Directory.Exists(ParamtersInput.SelectedPath))
                Directory.CreateDirectory(ParamtersInput.SelectedPath);
        }
    }
}
