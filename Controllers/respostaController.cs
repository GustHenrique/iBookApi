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
                client.BaseAddress = new Uri("https://api.mailgun.net/v3/sandboxb55da31b409a43a5b6636e7b4f0133ce.mailgun.org");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("api:94874e7ca0ca69b9af5851f7764861d1-e5475b88-28c56cd3")));

                string domain = "sandboxb55da31b409a43a5b6636e7b4f0133ce.mailgun.org";
                string from = "iBook <suporteibookoficial@gmail.com>";
                string to1 = "gust.leles2@gmail.com";
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
