using Dapper.Contrib.Extensions;

namespace mysqlAPI.DTOs
{
    [Table("OBRAS")]
    public class obraDTO
    {
        [Key]
        private int id { get; set; }
        private string title { get; set; }
        private string? subtitle { get; set; }
        private string? synopsis { get; set; }
        private string? author { get; set; }
        private string? editora { get; set; }
        private DateTime? dataPublicacao { get; set; }
        private DateTime? dataFinalizacao { get; set; }
        private string? isbn { get; set; }
        private int? paginas { get; set; }
        private string? image { get; set; }
        private string? traducao { get; set; }
        private string? tipo { get; set; }
        private float? avarageRating { get; set; }
        private string? statusObra { get; set; }
        private string? categorias { get; set; }
    }
}