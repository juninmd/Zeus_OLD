namespace Zeus.Core.SGBD.Microsoft_SQL
{
    public class SQLEntidadeTabela
    {
        public string COLUMN_NAME { get; set; }

        public string DATA_TYPE { get; set; }

        public int CHARACTER_MAXIMUM_LENGTH { get; set; }

        public bool IS_NULLABLE { get; set; }

        public string COMMENTS { get; set; }

        /// <summary>
        ///     Para descobrir a precisão do campo. EX: NUMBER(9,*);
        /// </summary>
        public decimal? NUMERIC_PRECISION { get; set; }

        /// <summary>
        ///     Para descobrir a precisão do campo. EX: NUMBER(*,2);
        /// </summary>
        public int? NUMERIC_SCALE { get; set; }
    }
}