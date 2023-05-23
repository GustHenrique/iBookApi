using Dapper.Contrib.Extensions;

namespace mysqlAPI.DTOs
{
    [Table("RESPOSTAS")]
    public class respostaDTO
    {
        public int resid { get; set; }
        public int comid { get; set; }
        public int usuid { get; set; }
        public int obid { get; set; }
        public string resposta { get; set; }
    }
}
