using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackgroundStrategy.ViewModels
{
    public class WeatherAPIViewModel
    {
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
    }
    public class Weather
    {
        public string main { get; set; }
        public string description { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
    }
}
