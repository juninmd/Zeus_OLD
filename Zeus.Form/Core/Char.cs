using System.Linq;

namespace Zeus.Core
{
    public static class Char
    {
        public static string ToFirstCharToUpper(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;
            return input.First().ToString().ToUpper() + input.Substring(1).ToLower();
        }
    }
}