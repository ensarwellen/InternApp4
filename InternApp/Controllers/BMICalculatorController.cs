using InternApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternApp.Controllers
{
    public class BMICalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
            public double CalculateBMI(double weight, double height)
            {
                // BMI hesaplama formülünü uygula
                double bmi = weight / (height * height);
                double bmiRounded = Math.Round(bmi,2);
                return bmiRounded;
            }
        
        [HttpPost]
        public IActionResult Calculate(BMICalculator model)
        {
            if (ModelState.IsValid)
            {
                //BMICalculator2 calculator = new BMICalculator2();
                double bmiResult = CalculateBMI(model.Weight, model.Height);

                // Sonucu JSON olarak döndür
                return Json(new { bmi = bmiResult });
            }

            return BadRequest("Geçersiz veri");
        }
        //public IActionResult Calculate(BMICalculator obj)
        //{

        //    var bmi = obj.Weight / ((obj.Height) * (obj.Height));
        //    if (bmi < 18.5)
        //    {
        //        var bmiRounded = Math.Round(bmi, 2);
        //        ViewBag.Bmi = bmiRounded;
        //        ViewBag.BmiResult = "İdeal Kilonun Altında";
        //    }else if(bmi >=18.5 && bmi < 24.9)
        //    {
        //        var bmiRounded = Math.Round(bmi, 2);
        //        ViewBag.Bmi = bmiRounded;
        //        ViewBag.BmiResult = "İdeal Kiloda";
        //    }else if(bmi >25 && bmi < 29.9)
        //    {
        //        var bmiRounded = Math.Round(bmi, 2);
        //        ViewBag.Bmi = bmiRounded;
        //        ViewBag.BmiResult = "İdeal Kilonun üstünde";
        //    }else if(bmi >30 && bmi < 39.9)
        //    {
        //        var bmiRounded = Math.Round(bmi, 2);
        //        ViewBag.Bmi = bmiRounded;
        //        ViewBag.BmiResult = "İdeal Kilonun çok üstünde (Obez)";
        //    }
        //    else
        //    {
        //        var bmiRounded = Math.Round(bmi, 2);
        //        ViewBag.Bmi = bmiRounded;
        //        ViewBag.BmiResult = "İdeal Kilonun çok üstünde (Morbid Obez)";
        //    }
        //    return View("Index");
        //}

    }
}
