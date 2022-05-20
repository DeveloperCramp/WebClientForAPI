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
            var response = await httpClient.GetAsync($"token?login={userViewModel.Login}&password={userViewModel.Password}");

            if (!response.IsSuccessStatusCode)
            {
                return response.ReasonPhrase;
            }

            var contentStream = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserViewModel>(contentStream);
            return user.Token;
        }
    }
}
