//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace WebApplication.Project.Controllers
//{
//    [Route("api/[controller]/[action]")]
//    [ApiController]
//    public class HttpClientController : ControllerBase
//    {
//        public async Task<IActionResult> GetJson()
//        {
//            using (HttpClient client = new HttpClient())
//            {
//                try
//                {
//                    HttpResponseMessage response = await client.GetAsync("https://api.example.com/data");

//                    if (response.IsSuccessStatusCode)
//                    {
//                        string content = await response.Content.ReadAsStringAsync();
//                        Console.WriteLine("Başarılı yanıt alındı:");
//                        Console.WriteLine(content);
//                    }
//                    else
//                    {
//                        Console.WriteLine($"İstek başarısız oldu. Durum Kodu: {response.StatusCode}");
//                    }
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine($"Hata: {e.Message}");
//                }
//            }
//        }
//    }
//}
