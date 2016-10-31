using System;
using System.Text;

namespace MapeadorDeEntidades.Form.Core.SGBD.Oracle.Sequence
{
    public class OracleSequence
    {
        public string Init(string nomeTabela)
        {
            var s = new StringBuilder();
            s.Append($"create sequence {nomeTabela.TratarNomeSequence().Replace(".NEXTVAL", "")}{Environment.NewLine}");
            s.Append($"minvalue 0 {Environment.NewLine}");
            s.Append($"maxvalue 99999 {Environment.NewLine}");
            s.Append($"start with 1 {Environment.NewLine}");
            s.Append($"increment by 1{Environment.NewLine}");
            return s.ToString();

        }
    }
}
