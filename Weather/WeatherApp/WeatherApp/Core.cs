using System;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string city)
        {
            //Sign up for a free API key at http://openweathermap.org/appid
            string key = "a7614ba095d0b972a296a1b824562197";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?q="
                + city + "&appid=" + key+"&units=metric";

            var results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Title = (string)results["name"];
                weather.Temperature = (string)results["main"]["temp"] + " C";
                weather.Wind = (string)results["wind"]["speed"] + " mps";
                weather.Humidity = (string)results["main"]["humidity"] + " %";
                weather.Visibility = (string)results["weather"][0]["main"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
				sunrise = sunrise.ToLocalTime();
				sunset = sunset.ToLocalTime();
                weather.Sunrise = sunrise.ToString() + " IST";
                weather.Sunset = sunset.ToString() + " IST";
                return weather;
            }
            else
            {
                return null;
            }
        }
    }
}