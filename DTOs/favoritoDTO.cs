using Dapper.Contrib.Extensions;

namespace mysqlAPI.DTOs
{
    [Table("OBRAS_FAVORITAS")]
    public class favoritoDTO
    {
        public int usuid { get; set; }
        public int obid { get; set; }
    }
}
