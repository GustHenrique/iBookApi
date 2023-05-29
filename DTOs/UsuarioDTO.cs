using Dapper.Contrib.Extensions;

namespace mysqlAPI.DTOs
{
    [Table("USUARIO")]
    public class UsuarioDTO
    {
        [Key]
        public string? ID { get; set; }
        public string NOME { get; set; }
        public string EMAIL { get; set; }
        public string SENHA { get; set; }
        public string? IMAGEM { get; set; }
        public bool ADMINISTRADOR { get; set; }
    }
}