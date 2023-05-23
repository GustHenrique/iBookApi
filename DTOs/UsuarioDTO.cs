using Dapper.Contrib.Extensions;

namespace mysqlAPI.DTOs
{
    [Table("USUARIO")]
    public class UsuarioDTO
    {
        [Key]
        public decimal USUID { get; set; }
        public decimal? PCLID { get; set; }
        public string? USULOGIN { get; set; }
        public string? USUEMAIL { get; set; }
        public string? USUNOMECOMPLETO { get; set; }
        public string? USUSENHA { get; set; }
        public DateTime USUDATAHORACRIACAO { get; set; }
        public bool USUATIVO { get; set; }
        public bool ADMIN { get; set; }
        public bool USUBLOQUEIOETAPAS { get; set; }
        public decimal? USUIDCLIENTE { get; set; }
        public bool USUALTERASENHA { get; set; }
        public bool USUBLOQUEIOHORARIO { get; set; }
        public bool USUCONSULTASUA { get; set; }
        public decimal? cliDocId { get; set; }
        public bool USUASSINADOCS { get; set; }
        public string? USUCERTIFICADODIGITAL { get; set; }
        public string? USUSENHACERTIFICADO { get; set; }
        public string? USUPROFISSAO { get; set; }
        public bool USUIGNORAORIGEMFILA { get; set; }
        public string? USUCPF { get; set; }
        public string? USUTELEFONE { get; set; }
    }
}