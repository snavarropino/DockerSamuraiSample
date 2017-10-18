using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SamuraiWeb.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var samurais=await GetSauirais();

            return View(samurais);
        }

        private async Task<List<string>> GetSauirais()
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync("http://localhost:5001/api/samurais");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    var samurais = JsonConvert.DeserializeObject<List<string>>(jsonString.Result);
                    return samurais;
                }
                else
                {
                    return new List<string>() {"ERROR"};
                }
            }
            catch
            {
                return new List<string>() { "Excepcion" };
            }

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
