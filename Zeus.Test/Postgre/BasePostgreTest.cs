using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Zeus.Core;

namespace Zeus.Test.Postgre
{
    public class BasePostgreTest
    {
        public BasePostgreTest()
        {
            ParamtersInput.ConnectionString = ConfigurationManager.AppSettings["pgConnect"];
            ParamtersInput.NomeTabelas = new List<string> {"teste"};
            ParamtersInput.SelectedPath = Directory.GetCurrentDirectory() + "\\Test\\";
            ParamtersInput.SGBD = 5;

            if (!Directory.Exists(ParamtersInput.SelectedPath))
                Directory.CreateDirectory(ParamtersInput.SelectedPath);
        }
    }
}