using InternApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InternApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<AppCards> cards = new List<AppCards>();
            AppCards card1 = new AppCards();
            card1.Id = 1;
            card1.Title = "BMI Hesaplayıcı";
            card1.Text ="Vücut kitle endeksinizi öğrenin!";
            card1.Img = "https://wellversed.in/cdn/shop/articles/shutterstock_584016211_1_1170x.jpg?v=1596612878";

            AppCards card2 = new AppCards();
            card2.Id = 2;
            card2.Title = "Özlü Sözler";
            card2.Text = "Rastgele bir özlü söz okuyun!";
            card2.Img = "https://ares.shiftdelete.net/2021/11/Nikola-Tesla-4.jpg-4.jpg";

            AppCards card3 = new AppCards();
            card3.Id = 3;
            card3.Title = "Yapılacaklar Listesi";
            card3.Text = "Planlarınızı unutmamak için buraya kaydedin!";
            card3.Img = "https://imageio.forbes.com/specials-images/dam/imageserve/1092571024/960x0.jpg?height=474&width=711&fit=bounds";

            AppCards card4 = new AppCards();
            card4.Id = 4;
            card4.Title = "Hava Durumu";
            card4.Text = "Hava durumu bilgilerine ulaşın!";
            card4.Img = "https://iskenderunorg.teimg.com/crop/1280x720/iskenderun-org/uploads/2023/05/agency/igf/bugun-hava-durumu-nasil-olacak.jpg";

            cards.Add(card1);
            cards.Add(card2);
            cards.Add(card3);
            cards.Add(card4);


            return View(cards);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}