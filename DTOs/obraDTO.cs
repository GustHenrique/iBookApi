using Dapper.Contrib.Extensions;

namespace mysqlAPI.DTOs
{
    [Table("OBRAS")]
    public class obraDTO
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string? subtitle { get; set; }
        public string? synopsis { get; set; }
        public string? author { get; set; }
        public string? editora { get; set; }
        public DateTime? dataPublicacao { get; set; }
        public DateTime? dataFinalizacao { get; set; }
        public string? isbn { get; set; }
        public int? paginas { get; set; }
        public string? image { get; set; }
        public string? traducao { get; set; }
        public string? tipo { get; set; }
        public float? avarageRating { get; set; }
        public string? statusObra { get; set; }
        public string? categorias { get; set; }
        public int? usuid { get; set; }
    }
}
