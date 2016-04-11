using System;

namespace MapeadorDeEntidades.Form.Linguagens
{
    public class BaseEntity
    {
        protected static string N => Environment.NewLine;

        public bool IsNullabe(string aceitaNull)
        {
            return aceitaNull == "Y";
        }
    }
}
