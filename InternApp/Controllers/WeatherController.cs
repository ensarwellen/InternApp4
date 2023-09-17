using InternApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace InternApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            string apiKey = "14f8be240561170362e0ba0ec4ad7f4c";
            string[] cities = { "Milano", "Berlin", "Istanbul" };
            var weatherDataList = new List<Root>();

            foreach (var city in cities)
            {
                var httpClient = _httpClientFactory.CreateClient();

                // API isteği yapıyoruz
                var response = await httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric&&lang=tr");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var weatherData = JsonSerializer.Deserialize<Root>(content);
                    weatherDataList.Add(weatherData);
                }
            }
            //for (var i = weatherDataList.Count; i < 3; i++)
            //{
            //    weatherDataList.Add(null);
            //}
            return View(weatherDataList);
        }
        public async Task<IActionResult> Search(string city)
        {
            string apiKey = "14f8be240561170362e0ba0ec4ad7f4c";
            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric&&lang=tr");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var weatherData = JsonSerializer.Deserialize<Root>(content);
                return PartialView("_WeatherPartial", weatherData);
            }
            else
            {
                return PartialView("_ErrorPartial", city);
            }
        }

        public IActionResult GetWeatherIcon(string iconCode)
        {
            // resim dosyasının yolunu oluşturuyoruz
            var imagePath = $"/images/{iconCode}.png"; 

            // Dosya yolunu döndürme işlemi
            return File(imagePath, "image/png"); 
        }

    }
}
