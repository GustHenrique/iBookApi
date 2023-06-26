using Dapper.Contrib.Extensions;

namespace mysqlAPI.DTOs
{
    [Table("AVALIACOES")]
    public class avaliacaoDTO
    {
        [Key]
        public int id { get; set; }
        public int usuid { get; set; }
        public int obid { get; set; }
        public float AVALIACAO { get; set; }
    }
}
