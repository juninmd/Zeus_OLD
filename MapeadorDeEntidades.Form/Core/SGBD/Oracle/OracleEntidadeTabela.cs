namespace MapeadorDeEntidades.Form.Core.SGBD.Oracle
{
    public class OracleEntidadeTabela
    {
        public string COLUMN_NAME { get; set; }

        public string DATA_TYPE { get; set; }

        public decimal CHAR_LENGTH { get; set; }

        public string NULLABLE { get; set; }

        public string COMMENTS { get; set; }

        /// <summary>
        /// Para descobrir a precisão do campo. EX: NUMBER(9,*);
        /// </summary>
        public decimal? DATA_PRECISION { get; set; }

        /// <summary>
        ///  Para descobrir a precisão do campo. EX: NUMBER(*,2);
        /// </summary>
        public decimal? DATA_SCALE { get; set; }



    }
}
