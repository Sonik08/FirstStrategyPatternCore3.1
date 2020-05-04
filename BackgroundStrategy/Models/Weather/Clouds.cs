using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackgroundStrategy.Models.Weather
{
    public class Clouds : IWeather
    {
        public string IconPath { get; set; } = "/Icons/Cloudy.jpg";

        public string AddBackground()
        {
            return IconPath;
        }
    }
}