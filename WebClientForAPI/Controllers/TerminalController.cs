using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebClientForAPI.Controllers
{

    public class TerminalController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TerminalController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ActionResult> Index()
        {
            string token = (string)TempData["token"];
            var client = _httpClientFactory.CreateClient("ClientAPI");
            var request = await client.GetAsync($"commands/types?token={token}");

            if (!request.IsSuccessStatusCode)
            {
                return View(request);
            }

            return View();
        }
    }
}
