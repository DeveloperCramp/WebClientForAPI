using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using WebClientForAPI.Models;


namespace WebClientForAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public async Task<ActionResult> LoginAsync(UserViewModel userViewModel)
        {
            var client = _httpClientFactory.CreateClient("ClientAPI");
            var request = await client.GetAsync($"token?login={userViewModel.Login}&password={userViewModel.Password}");

            if (!request.IsSuccessStatusCode)
            {
                return View();
            }

            //Get Token
            var contentStream = await request.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<UserViewModel>(contentStream);
            TempData["token"] = result.Token;
            return RedirectToAction("Index", "Terminal");
        }
    }
}
