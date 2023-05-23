using Dapper.Contrib.Extensions;

namespace mysqlAPI.DTOs
{
    [Table("COMENTARIOS")]
    public class comentarioDTO
    {
        [Key]
        public int comid { get; set; }
        public int usuid { get; set; }
        public int obid { get; set; }
        public string comentario { get; set; }
        public List<respostaDTO> respostas { get; set; }
    }
}
