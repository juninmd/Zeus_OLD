using System;
using Zeus.Properties;

namespace Zeus.Core
{
    public static class Tratamentos
    {
        public static string TratarNomeTabela(this string nome)
        {
            if (String.IsNullOrEmpty(ParamtersInput.Prefixos.Tabela))
            {
                return nome;
            }
            return nome.ToUpper().Replace(ParamtersInput.Prefixos.Tabela.ToUpper(), "");
        }
        public static string TratarNomeTabelaMySql(this string nome)
        {
            if (String.IsNullOrEmpty(ParamtersInput.Prefixos.Tabela))
            {
                return nome;
            }
            return nome.ToLower().Replace(ParamtersInput.Prefixos.Tabela.ToLower(), "");
        }

        public static string TratarNomePackage(this string nome)
        {
            if (String.IsNullOrEmpty(ParamtersInput.Prefixos.Tabela) ||
                String.IsNullOrEmpty(ParamtersInput.Prefixos.Package))
            {
                return nome;
            }
            return nome.ToUpper().Replace(ParamtersInput.Prefixos.Tabela.ToUpper(), ParamtersInput.Prefixos.Package);
        }
        public static string TratarNomeBase(this string nome) { return $"\"{nome.Split(';')[1].Split('=')[1]}\""; }
    }
}
