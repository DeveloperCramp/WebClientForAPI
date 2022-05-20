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
        public async Task<string> LoginAsync(UserViewModel userViewModel)
        {
            var httpClient = _httpClientFactory.CreateClient("ClientAPI");
            var request = await httpClient.GetAsync($"token?login={userViewModel.Login}&password={userViewModel.Password}");

            if (!request.IsSuccessStatusCode)
            {
                return request.ReasonPhrase;
            }

            var contentStream = await request.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserViewModel>(contentStream);
            return user.Token;
        }
    }
}
