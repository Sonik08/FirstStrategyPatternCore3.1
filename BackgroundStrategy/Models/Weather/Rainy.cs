using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackgroundStrategy.Models.Weather
{
    public class Rainy : IWeather
    {
        public string IconPath { get; set; } = "/Icons/Rainy.jpg";

        public string AddBackground()
        {
            return IconPath;
        }
    }
}