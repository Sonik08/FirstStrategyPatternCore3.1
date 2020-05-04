using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackgroundStrategy.Models.Weather
{
    public class Snowy : IWeather
    {
        public string IconPath { get; set; } = "/Icons/Snowy.jpg";

        public string AddBackground()
        {
            return IconPath;
        }
    }
}