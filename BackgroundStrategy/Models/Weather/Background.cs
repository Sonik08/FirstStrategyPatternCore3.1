using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackgroundStrategy.Models.Weather
{
    public class Background
    {
        private IWeather _weatherBackground;
        public decimal Temp { get; set; }

        public void SetInitialBackground(IWeather weatherBackground)
        {
            _weatherBackground = weatherBackground;
        }

        public string GetBackground()
        {
            return _weatherBackground.AddBackground();
        }

        public void ChooseBackground(string weatherNow)
        {
            switch (weatherNow)
            {
                case ("Thunderstorm"):
                    SetInitialBackground(new Thunderstorm());
                        break;
                case ("Drizzle"):
                    SetInitialBackground(new Drizzly());
                        break;
                case ("Rain"):
                    SetInitialBackground(new Rainy());
                    break;
                case ("Clouds"):
                    SetInitialBackground(new Clouds());
                    break;
                case ("Clear"):
                    SetInitialBackground(new Sunny());
                    break;
                case ("Snow"):
                    SetInitialBackground(new Snowy());
                    break;
                default:
                    SetInitialBackground(new Sunny());
                    break;
            }
        }
    }
}