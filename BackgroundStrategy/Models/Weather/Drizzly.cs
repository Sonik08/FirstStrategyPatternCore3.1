using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackgroundStrategy.Models.Weather
{
    public class Drizzly : IWeather
    {
        public string IconPath { get; set; } = "/Icons/Drizzly.jpg";
        public string AddBackground()
        {
            return IconPath;
        }
    }
}