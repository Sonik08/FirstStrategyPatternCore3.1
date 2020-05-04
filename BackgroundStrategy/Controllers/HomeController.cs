using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BackgroundStrategy.Models;
using BackgroundStrategy.Models.Weather;
using System.Net;
using BackgroundStrategy.ViewModels;
using Nancy.Json;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MaxMind.GeoIP2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MaxMind.GeoIP2.Responses;

namespace BackgroundStrategy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IActionContextAccessor _accessor;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(ILogger<HomeController> logger, IActionContextAccessor accessor, IWebHostEnvironment hostingEnviroment)
        {
            _logger = logger;
            _accessor = accessor;
            _hostingEnvironment = hostingEnviroment;
        }

        public IActionResult Index()
        {
           

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region  API CALLS

        [HttpGet]
        public IActionResult GetBackground()
        {
            string path = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, @"GeoIPDB/GeoLite2-City.mmdb");
            CityResponse city = new CityResponse() { };
            using (var reader = new DatabaseReader(path))
            {
                var ip = _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString();
                city = reader.City(ip);
            }

            //Assign API KEY which received from OPENWEATHERMAP.ORG
            string appId = "51484507182468c91ba33387b57568d8";
            //API path with CITY parameter and other parameters.
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + city.City + "&units=metric&cnt=1&APPID=" + appId;
            Background background = new Background() { };

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherAPIViewModel weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherAPIViewModel>(json);

                background.ChooseBackground(weatherInfo.weather[0].main);
            }
            if(city.City == null)
                return Json(new { success = false, BackgroundImageUrl = background.GetBackground() });
            return Json(new { success = true, backgroundImageUrl = background.GetBackground() });
        }

        #endregion
    }
}
