namespace Zeus.Core
{
    public enum OperationProcedure
    {
        Search,
        List,
        Insert,
        Update,
        Delete
    }

    public static class Tratamentos
    {
        public static string TratarNomeTabela(this string nome)
        {
            if (string.IsNullOrEmpty(ParamtersInput.Prefixos.Tabela)) return nome;
            return nome.ToUpper().Replace(ParamtersInput.Prefixos.Tabela.ToUpper(), "");
        }

        public static string TratarNomeProcedure(this string nome, OperationProcedure operation)
        {
            switch (operation)
            {
                case OperationProcedure.Search:
                    return $"{ParamtersInput.Prefixos.Procedure}S_{nome.TratarNomeTabela().ToUpper()}_ID";
                case OperationProcedure.List:
                    return $"{ParamtersInput.Prefixos.Procedure}S_{nome.TratarNomeTabela().ToUpper()}";
                case OperationProcedure.Insert:
                    return $"{ParamtersInput.Prefixos.Procedure}I_{nome.TratarNomeTabela().ToUpper()}";
                case OperationProcedure.Update:
                    return $"{ParamtersInput.Prefixos.Procedure}U_{nome.TratarNomeTabela().ToUpper()}";
                case OperationProcedure.Delete:
                    return $"{ParamtersInput.Prefixos.Procedure}D_{nome.TratarNomeTabela().ToUpper()}_ID";
                default:
                    return "";
            }
        }

        public static string TratarNomeTabelaMySql(this string nome)
        {
            if (string.IsNullOrEmpty(ParamtersInput.Prefixos.Tabela)) return nome;
            return nome.ToLower().Replace(ParamtersInput.Prefixos.Tabela.ToLower(), "");
        }

        public static string TratarNomePackage(this string nome)
        {
            if (string.IsNullOrEmpty(ParamtersInput.Prefixos.Tabela) ||
                string.IsNullOrEmpty(ParamtersInput.Prefixos.Package))
                return nome;
            return nome.ToUpper().Replace(ParamtersInput.Prefixos.Tabela.ToUpper(), ParamtersInput.Prefixos.Package);
        }

        public static string TratarNomeBase(this string nome)
        {
            return $"\"{nome.Split(';')[1].Split('=')[1]}\"";
        }
    }
}