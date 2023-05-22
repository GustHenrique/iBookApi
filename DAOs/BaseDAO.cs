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
            ConnectionString = "Server=ibook.cph5uy7z0yhy.us-east-2.rds.amazonaws.com;Port=3306;Database=ibook;Uid=admin;Pwd=Pid4ceub!;";
        }

        public DataTable ExecuteDataTable(string SQL)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                DataTable dtResult = new DataTable();

                SqlCommand cmd = new SqlCommand(SQL, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtResult);

                return dtResult;
            }
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
