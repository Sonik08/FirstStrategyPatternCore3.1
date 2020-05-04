using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackgroundStrategy.Models.Weather
{
    public class Thunderstorm : IWeather
    {
        public string IconPath { get; set; } = "/Icons/Thunderstorm.jpg";

        public string AddBackground()
        {
            return IconPath;
        }
    }
}