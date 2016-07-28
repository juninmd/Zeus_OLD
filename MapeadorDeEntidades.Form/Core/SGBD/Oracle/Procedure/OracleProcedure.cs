using System;
using System.Collections.Generic;
using System.Text;

namespace MapeadorDeEntidades.Form.Core.SGBD.Oracle.Procedure
{
    public class OracleProcedure
    {
        public string NomeTabela { get; set; }

        public List<OracleEntidadeTabela> ListaAtributosTabela { get; set; }

        public OracleProcedure(string nomeTabela, List<OracleEntidadeTabela> atributosTabela)
        {
            NomeTabela = nomeTabela;
            ListaAtributosTabela = atributosTabela;
        }

        #region PRIVATE 
        public StringBuilder MontarSumario(string nomeProcedure)
        {
            var desc = new StringBuilder();
            desc.Append(Environment.NewLine);
            desc.Append("  /*****************************************************************************" + Environment.NewLine);
            desc.Append($"  //* NOME DA PROCEDURE: {nomeProcedure}" + Environment.NewLine);
            desc.Append("  //*****************************************************************************" + Environment.NewLine);
            desc.Append("  //* DESCRICAO: --" + Environment.NewLine);
            desc.Append("  //* AUTOR: -- " + Environment.NewLine);
            desc.Append("  //* FABRICA: ENGSOLUTIONS" + Environment.NewLine);
            desc.Append($"  //* DATA DA CRIACAO: {DateTime.Now.ToShortDateString()}" + Environment.NewLine);
            desc.Append("  //* DATA DA ULTIMA ALTERACAO: -" + Environment.NewLine);
            desc.Append("  //*****************************************************************************/" + Environment.NewLine);
            return desc;
        }

        private string EspacoMontadoParametros(string nomeProcedure)
        {
            var tamanho = $"  PROCEDURE {nomeProcedure} ".Length;
            var espaco = "";
            for (int t = 0; t < tamanho; t++)
            {
                espaco += " ";
            }
            return espaco;
        }

        private StringBuilder MontaTodosParametrosHeader(string nomeProcedure, bool isCursor, bool isHeader, bool onlyFirst = false, bool semparametros = false)
        {

            var parametro = new StringBuilder();
            parametro.Append($"  PROCEDURE {nomeProcedure}(");


            parametro.Append(isCursor ? "P_CURSORSELECT               OUT TP_CURSOR" : "P_RESULT               OUT STRING");

            if (semparametros == false)
            {
                parametro.Append("," +Environment.NewLine);
                if (onlyFirst == false)
                {
                    for (var i = 0; i < ListaAtributosTabela.Count; i++)
                    {
                        if (i == ListaAtributosTabela.Count - 1)
                        {
                            parametro.Append(EspacoMontadoParametros(nomeProcedure) + $"P_{ListaAtributosTabela[i].COLUMN_NAME}        IN {NomeTabela}.{ListaAtributosTabela[i].COLUMN_NAME}%TYPE ");
                        }
                        else
                        {
                            parametro.Append(EspacoMontadoParametros(nomeProcedure) + $"P_{ListaAtributosTabela[i].COLUMN_NAME}        IN {NomeTabela}.{ListaAtributosTabela[i].COLUMN_NAME}%TYPE, " + Environment.NewLine);
                        }
                    }
                }
                else
                {
                    parametro.Append(EspacoMontadoParametros(nomeProcedure) + $"P_{ListaAtributosTabela[0].COLUMN_NAME}        IN {NomeTabela}.{ListaAtributosTabela[0].COLUMN_NAME}%TYPE");
                }

            }
            parametro.Append(")");

            parametro.Append(isHeader ? ";" : " IS");

            return parametro;
        }

        private StringBuilder MontaTodosParametrosInsert()
        {
            var parametro = new StringBuilder();
            parametro.Append($"      INSERT INTO {NomeTabela}" + Environment.NewLine);
            parametro.Append("         (");

            for (var i = 0; i < ListaAtributosTabela.Count; i++)
            {
                if (i == ListaAtributosTabela.Count - 1)
                {
                    parametro.Append($"         {ListaAtributosTabela[i].COLUMN_NAME}");
                }
                else if (i == 0)
                {
                    parametro.Append($"{ListaAtributosTabela[i].COLUMN_NAME}," + Environment.NewLine);
                }
                else
                {
                    parametro.Append($"         {ListaAtributosTabela[i].COLUMN_NAME}," + Environment.NewLine);
                }
            }

            parametro.Append(")" + Environment.NewLine);
            parametro.Append("      VALUES" + Environment.NewLine);
            parametro.Append("         (");
            for (var i = 0; i < ListaAtributosTabela.Count; i++)
            {
                if (i == ListaAtributosTabela.Count - 1)
                {
                    parametro.Append($"         P_{ListaAtributosTabela[i].COLUMN_NAME}");
                }
                else if (i == 0)
                {
                    parametro.Append($"P_{ListaAtributosTabela[i].COLUMN_NAME}," + Environment.NewLine);
                }
                else
                {
                    parametro.Append($"         P_{ListaAtributosTabela[i].COLUMN_NAME}," + Environment.NewLine);
                }
            }
            parametro.Append(");");

            return parametro;
        }

        private StringBuilder MontaTodosParametrosUpdate()
        {
            var parametro = new StringBuilder();
            parametro.Append($"      UPDATE {NomeTabela}" + Environment.NewLine);
            parametro.Append(Environment.NewLine);

            parametro.Append("         SET ");

            for (var i = 0; i < ListaAtributosTabela.Count; i++)
            {
                if (i == ListaAtributosTabela.Count - 1)
                {
                    parametro.Append($"         {ListaAtributosTabela[i].COLUMN_NAME}        = P_{ListaAtributosTabela[i].COLUMN_NAME}" + Environment.NewLine);
                }
                else if (i == 0)
                {
                    parametro.Append($"{ListaAtributosTabela[i].COLUMN_NAME}        = P_{ListaAtributosTabela[i].COLUMN_NAME}," + Environment.NewLine);
                }
                else
                {
                    parametro.Append($"         {ListaAtributosTabela[i].COLUMN_NAME}        = P_{ListaAtributosTabela[i].COLUMN_NAME}," + Environment.NewLine);
                }
            }
            parametro.Append($"         WHERE {ListaAtributosTabela[0].COLUMN_NAME}        = P_{ListaAtributosTabela[0].COLUMN_NAME};" + Environment.NewLine);

            return parametro;
        }

        private StringBuilder MontaTodosParametrosDelete()
        {
            var parametro = new StringBuilder();
            parametro.Append($"      DELETE  FROM {NomeTabela}" + Environment.NewLine);
            parametro.Append($"      WHERE {ListaAtributosTabela[0].COLUMN_NAME}        = P_{ListaAtributosTabela[0].COLUMN_NAME};" + Environment.NewLine);
            return parametro;
        }

        private StringBuilder MontaTodosParametrosSelect(bool isAll)
        {
            var parametro = new StringBuilder();
            parametro.Append($"      SELECT ");

            for (var i = 0; i < ListaAtributosTabela.Count; i++)
            {
                if (i == ListaAtributosTabela.Count - 1)
                {
                    parametro.Append($"      {ListaAtributosTabela[i].COLUMN_NAME}" + Environment.NewLine);
                }
                else if (i == 0)
                {
                    parametro.Append($"{ListaAtributosTabela[i].COLUMN_NAME}," + Environment.NewLine);
                }
                else
                {
                    parametro.Append($"             {ListaAtributosTabela[i].COLUMN_NAME}," + Environment.NewLine);
                }
            }

            parametro.Append($"      FROM {NomeTabela}" + (isAll ? ";" : "") + Environment.NewLine);


            if (!isAll)
                parametro.Append($"      WHERE {ListaAtributosTabela[0].COLUMN_NAME}        = P_{ListaAtributosTabela[0].COLUMN_NAME};" + Environment.NewLine);

            return parametro;
        }

        public StringBuilder AdicionaCabecalho(string nomeProcedure, bool isHeader = false, bool isCursor = false, bool onlyFirst = false, bool semParametros = false)
        {
            var cabecalho = new StringBuilder();
            cabecalho.Append(MontarSumario(nomeProcedure));
            cabecalho.Append(MontaTodosParametrosHeader(nomeProcedure, isCursor, isHeader, onlyFirst, semParametros));
            return cabecalho;
        }

        #endregion

        private StringBuilder Adiciona_P_Result()
        {
            var body = new StringBuilder();
            body.Append(Environment.NewLine + "  BEGIN" + Environment.NewLine);
            body.Append("    P_RESULT := '1';" + Environment.NewLine + Environment.NewLine);
            return body;
        }

        private StringBuilder Adiciona_TratamentoException()
        {
            var body = new StringBuilder();
            body.Append(Environment.NewLine + "           EXCEPTION" + Environment.NewLine);
            body.Append("           WHEN OTHERS THEN" + Environment.NewLine);
            body.Append("           P_RESULT:= SQLERRM;" + Environment.NewLine);
            return body;
        }

        #region Insert 
        private StringBuilder InsertBodyInside()
        {
            var body = new StringBuilder();
            body.Append(Adiciona_P_Result());
            body.Append("  BEGIN" + Environment.NewLine);
            body.Append(MontaTodosParametrosInsert());
            body.Append(Adiciona_TratamentoException());
            body.Append(" END;" + Environment.NewLine);
            return body;
        }

        private StringBuilder BodyInsert()
        {
            var body = new StringBuilder();
            body.Append(Environment.NewLine);
            var nomeProc = "MAG_SP_PDL_I_" + NomeTabela.Replace("MAG_T_PDL", "").Replace("_", "");
            body.Append(AdicionaCabecalho(nomeProc));
            body.Append(InsertBodyInside());
            body.Append($"END {nomeProc};" + Environment.NewLine);
            body.Append(Environment.NewLine);
            return body;

        }
        #endregion

        #region Update 
        private StringBuilder UpdateBodyInside()
        {
            var body = new StringBuilder();
            body.Append(Adiciona_P_Result());
            body.Append("  BEGIN" + Environment.NewLine);
            body.Append(MontaTodosParametrosUpdate());
            body.Append(Adiciona_TratamentoException());
            body.Append(" END;" + Environment.NewLine);
            return body;
        }

        private StringBuilder BodyUpdate()
        {
            var body = new StringBuilder();
            body.Append(Environment.NewLine);
            var nomeProc = "MAG_SP_PDL_U_" + NomeTabela.Replace("MAG_T_PDL", "").Replace("_", "");
            body.Append(AdicionaCabecalho(nomeProc));
            body.Append(UpdateBodyInside());
            body.Append($"END {nomeProc};" + Environment.NewLine);
            body.Append(Environment.NewLine);
            return body;

        }
        #endregion

        #region Select 
        private StringBuilder SelectBodyInside(bool Isall)
        {
            var body = new StringBuilder();
            body.Append(Environment.NewLine);
            body.Append("  BEGIN" + Environment.NewLine);
            body.Append("     OPEN P_CURSORSELECT FOR" + Environment.NewLine);
            body.Append(MontaTodosParametrosSelect(Isall));
            return body;
        }

        private StringBuilder BodySelect(bool Isall = false)
        {
            var body = new StringBuilder();
            body.Append(Environment.NewLine);
            var nomeProc = "MAG_SP_PDL_S_" + NomeTabela.Replace("MAG_T_PDL", "").Replace("_", "") + (Isall ? "" : "_ID");
            body.Append(AdicionaCabecalho(nomeProc, false, true, true, Isall));
            body.Append(SelectBodyInside(Isall));
            body.Append($"END {nomeProc};" + Environment.NewLine);
            body.Append(Environment.NewLine);
            return body;

        }
        #endregion

        #region Delete 
        private StringBuilder DeleteBodyInside()
        {
            var body = new StringBuilder();
            body.Append(Adiciona_P_Result());
            body.Append("  BEGIN" + Environment.NewLine);
            body.Append(MontaTodosParametrosDelete());
            body.Append(Adiciona_TratamentoException());
            body.Append("     END;" + Environment.NewLine);
            return body;
        }

        private StringBuilder BodyDelete()
        {
            var body = new StringBuilder();
            body.Append(Environment.NewLine);
            var nomeProc = "MAG_SP_PDL_D_" + NomeTabela.Replace("MAG_T_PDL", "").Replace("_", "");
            body.Append(AdicionaCabecalho(nomeProc, false, false, true));
            body.Append(DeleteBodyInside());
            body.Append($"END {nomeProc};" + Environment.NewLine);
            body.Append(Environment.NewLine);
            return body;

        }
        #endregion

        public StringBuilder GerarPackageHeader()
        {
            var header = new StringBuilder();
            header.Append($"create or replace package {NomeTabela.Replace("_T_", "_PG_")} is" + Environment.NewLine + Environment.NewLine);
            header.Append("  TYPE TP_CURSOR IS REF CURSOR;" + Environment.NewLine + Environment.NewLine);
            header.Append(AdicionaCabecalho("MAG_SP_PDL_I_" + NomeTabela.Replace("MAG_T_PDL", "").Replace("_", ""), true, false, false));
            header.Append(AdicionaCabecalho("MAG_SP_PDL_U_" + NomeTabela.Replace("MAG_T_PDL", "").Replace("_", ""), true, false, false));
            header.Append(AdicionaCabecalho("MAG_SP_PDL_D_" + NomeTabela.Replace("MAG_T_PDL", "").Replace("_", ""), true, false, true));
            header.Append(AdicionaCabecalho("MAG_SP_PDL_S_" + NomeTabela.Replace("MAG_T_PDL", "").Replace("_", ""), true, true, true, true));
            header.Append(AdicionaCabecalho("MAG_SP_PDL_S_" + NomeTabela.Replace("MAG_T_PDL", "").Replace("_", "") + "_ID", true, true, true));
            header.Append(Environment.NewLine + Environment.NewLine + $"end {NomeTabela.Replace("_T_", "_PG_")};" + Environment.NewLine);

            return header;
        }

        public StringBuilder GerarPackageBody()
        {
            var header = new StringBuilder();
            header.Append($"create or replace package BODY {NomeTabela.Replace("_T_", "_PG_")} is" + Environment.NewLine + Environment.NewLine);
            header.Append(BodyInsert());
            header.Append(BodyUpdate());
            header.Append(BodyDelete());
            header.Append(BodySelect());
            header.Append(BodySelect(true));
            header.Append($"end {NomeTabela.Replace("_T_", "_PG_")};" + Environment.NewLine);
            return header;
        }

    }
}
