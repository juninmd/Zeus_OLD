using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Zeus.Core;

namespace Zeus.Test.Firebird
{
    public class BaseFirebirdTest
    {
        public BaseFirebirdTest()
        {
            ParamtersInput.ConnectionString = ConfigurationManager.AppSettings["firebirdConnect"];

            ParamtersInput.NomeTabelas = new List<string> { "BAIRRO" };
            ParamtersInput.SelectedPath = Directory.GetCurrentDirectory() + "\\Test\\";
            ParamtersInput.SGBD = 4;

            if (!Directory.Exists(ParamtersInput.SelectedPath))
                Directory.CreateDirectory(ParamtersInput.SelectedPath);
        }
    }
}
