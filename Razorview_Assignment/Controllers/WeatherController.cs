using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Razorview_Assignment.Models;

namespace Razorview_Assignment.Controllers
{
    public class WeatherController : Controller
    {
        List<CityWeather> cityWeathers = new List<CityWeather>()
           {
           new CityWeather() { CityUniqueCode = "LDN", CityName = "London", DateAndTime =Convert.ToDateTime("2030-01-01 8:00"), TemperatureFahrenheit = 33 },
          new CityWeather() { CityUniqueCode = "NYC", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"), TemperatureFahrenheit = 60 },
           new CityWeather() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82 }
           };

        [Route("/")]
        public IActionResult Index()
        {
            
            return View(cityWeathers);
        }
        [Route("/weather/{citycode?}")]
        public IActionResult CityDetails(string? citycode)
        {
            if (string.IsNullOrEmpty(citycode))
            {
                return View();
            }
            CityWeather? city=  cityWeathers.Where(temp => temp.CityUniqueCode == citycode).FirstOrDefault();
            return View(city);



        }

        
    }
}
