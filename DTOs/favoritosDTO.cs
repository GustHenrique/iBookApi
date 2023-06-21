using Dapper.Contrib.Extensions;

namespace mysqlAPI.DTOs
{
    [Table("OBRAS_FAVORITAS")]
    public class favoritosDTO
    {
        [Key]
        public int id { get; set; }
        public int usuid { get; set; }
        public int obid { get; set; }
    }
}
