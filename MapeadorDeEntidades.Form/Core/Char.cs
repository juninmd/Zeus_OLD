using System;
using System.Linq;

namespace MapeadorDeEntidades.Form.Core
{
    public static class Char
    {
        public static string ToFirstCharToUpper(this string input)
        {
            if (String.IsNullOrEmpty(input))
                return null;
            return input.First().ToString().ToUpper() + input.Substring(1).ToLower();
        }
    }
}
