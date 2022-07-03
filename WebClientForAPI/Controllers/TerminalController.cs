using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using WebClientForAPI.Models;

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

            var contentStream = await request.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TerminalViewModel>(contentStream);

            return View(result);
        }

        public async Task<ActionResult> GetTerminalId(TerminalViewModel terminal)
        {
            var client = _httpClientFactory.CreateClient("ClientAPI");
            var request = await client.GetAsync($"terminals/{terminal.Id}");
            return View(request);
        }
    }
}
