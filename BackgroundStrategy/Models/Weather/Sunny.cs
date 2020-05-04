using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackgroundStrategy.Models.Weather
{
    public class Sunny : IWeather
    {
        public string IconPath { get; set; } = "/Icons/Sunny.jpg";

        public string AddBackground()
        {
            return IconPath;
        }
    }
}