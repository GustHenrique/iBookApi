using iBookApi.DAOs;
using Microsoft.AspNetCore.Mvc;
using mysqlAPI.DTOs;

namespace iBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespostaController : Controller
    {
        [HttpPost]
        [Route("EnviarEmail")]
        public void PostEnviarEmail([FromQuery]string name, [FromQuery] string email, [FromQuery] string newPass)
        {
            EnviarEmail(name, email,newPass);
        }

        static async Task EnviarEmail(string name, string email, string newPass)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.mailgun.net/v3/sandbox7f1d4c533efb42938bb2317ff700abcd.mailgun.org");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("api:9d0e1ed695ad4c6449b84a977860d0ec-e5475b88-6cd9e2e7")));

                string domain = "sandbox7f1d4c533efb42938bb2317ff700abcd.mailgun.org";
                string from = "iBook <suporteibookoficial@gmail.com>";
                string to1 = "gusthenrique273@gmail.com";
                string subject = "Recuperação de senha iBook";
                string text = "Querido " + name + ",\n" +
                                "\n" +
                                "Você solicitou uma nova senha pelo aplicativo.\n" +
                                "Sua nova senha é: " + newPass + "\n" +
                                "\n" +
                                "Atenciosamente,\n" +
                                "Time iBook";

                string resource = $"{domain}/messages";
                var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("from", from),
                new KeyValuePair<string, string>("to", to1),
                new KeyValuePair<string, string>("subject", subject),
                new KeyValuePair<string, string>("text", text)
            });

                HttpResponseMessage response = await client.PostAsync(resource, content);
              string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Mensagem enviada com sucesso!");
                }
                else
                {
                    Console.WriteLine($"Erro ao enviar mensagem: {responseBody}");
                }
            }
        }
    }
}
