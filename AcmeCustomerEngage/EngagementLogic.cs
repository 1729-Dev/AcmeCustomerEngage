using AcmeCustomerEngage.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeCustomerEngage
{
    public static class EngagementLogic
    {
        public static string CommunicationMethod(WeatherModel weatherSnapShot)
        {
            // Note per product owner (Genghis) requirements in the case of either
            // Email or Phone being applicable we shall give preference to Email
            if (Email(weatherSnapShot))
            {
                return "Email";
            }
            else if (Phone(weatherSnapShot))
            {
                return "Phone";
            }
            else if (Text(weatherSnapShot))
            {
                return "Text";
            }
            else
            {
                return "None";
            }
        }

        public static List<WeatherModel> TrimWeatherSnapshots(List<WeatherModel> weather)
        {
            // Per conversation with product owner (Genghis) we will remove today's weather snapshots
            // and only display strictly ones from the next five days
            weather.RemoveAll(x => x.Start.Date.Equals(DateTime.Now.Date));
            weather.RemoveAll(x => x.Start.Date > DateTime.Now.AddDays(5).Date);

            return weather;
        }

        public static string WeatherSnapshotsQuantity(List<WeatherModel> weather)
        {
            // Return an error if we have no weather snapshots
            if (weather.Count == 0)
            {
                return "Error - no weather snapshots available to display.";
            }

            // Return a warning if we have less than 5 days of weather snapshots
            if (weather.Find(x => x.Start.Date.Equals(DateTime.Now.AddDays(5).Date)) is null)
            {
                return "Warning - less than 5 days of weather snapshots available to display.";
            }

            return null;
        }

        private static bool Email(WeatherModel model)
        {
            // Email is recommended for temperatures between and including 55F to 75F
            return model.Temperature >= 55.0 && model.Temperature <= 75;
        }

        private static bool Phone(WeatherModel model)
        {
            // Phone is recommended for temperatures < 55F OR when raining
            return model.Temperature < 55.0 || model.Raining;
        }

        private static bool Text(WeatherModel model)
        {
            // Text is recommended for temperatures > 75F AND sunny
            return model.Temperature > 75.0 && model.Sunny;
        }
    }
}
