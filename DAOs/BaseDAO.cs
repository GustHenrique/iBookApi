using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace iBookApi.DAOs
{
    public class BaseDAO
    {
        public string ConnectionString = "";
        public BaseDAO()
        {
            string json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "ConfiguracoesAcessos.json");
            Configuracoes configuracoes = JsonConvert.DeserializeObject<Configuracoes>(json);
            ConnectionString = "Server=" + configuracoes.DataSource + ";Port=3306;Database=" + configuracoes.InitialCatalog + ";Uid=" + configuracoes.InitialCatalog + ";Pwd=" + configuracoes.InitialCatalog + ";";
        }
    }
    public class Configuracoes
    {
        public string InitialCatalog { get; set; }
        public string DataSource { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
    }
}
