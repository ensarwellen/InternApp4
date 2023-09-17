using InternApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternApp.Controllers
{
    public class QuoteController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public QuoteController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> GetRandomQuote()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();

                // API'ye istek gönder
                var response = await client.GetAsync("https://zenquotes.io/api/quotes");

                if (response.IsSuccessStatusCode)
                {
                    // JSON verisini Quote sınıfına çözümle
                    var json = await response.Content.ReadAsStringAsync();
                    var quotes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Quote>>(json);

                    if (quotes.Any())
                    {
                        // Rastgele bir alıntı seç
                        Random random = new Random();
                        int randomIndex = random.Next(0, quotes.Count);
                        var randomQuote = quotes[randomIndex];

                        // Alıntıyı ve yazarı birlikte göster
                        string fullQuote = $"{randomQuote.q}<br> - {randomQuote.a}";

                        return Ok(fullQuote);
                    }
                    else
                    {
                        return NotFound("No quotes found.");
                    }
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //public class QuoteResponse
        //{
        //    public string q { get; set; } // Alıntı
        //    public string a { get; set; } // Yazar
        //}
        //public async Task<IActionResult> GetRandomQuote()
        //{
        //    try
        //    {
        //        var client = _httpClientFactory.CreateClient();

        //        // API'ye istek gönder
        //        var response = await client.GetAsync("https://zenquotes.io/api/random");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            // JSON verisini QuoteResponse sınıfına çözümle
        //            var json = await response.Content.ReadAsStringAsync();
        //            var quoteResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<List<QuoteResponse>>(json);

        //            if (quoteResponse.Any())
        //            {
        //                // İlk alıntıyı ve yazarı al
        //                string quoteText = quoteResponse[0].q;
        //                string author = quoteResponse[0].a;

        //                // Alıntıyı ve yazarı birlikte göster
        //                string fullQuote = $"{quoteText}<br> - {author}";

        //                return Ok(fullQuote);
        //            }
        //            else
        //            {
        //                return NotFound("No quotes found.");
        //            }
        //        }
        //        else
        //        {
        //            return StatusCode((int)response.StatusCode);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}


    }
}
