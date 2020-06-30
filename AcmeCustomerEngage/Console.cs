using AcmeCustomerEngage.DataModels;
using System.Collections.Generic;

namespace AcmeCustomerEngage
{
    public class Console
    {
        public static void Main()
        {
            // Query and trim the weather snapshots to the correct date range
            WeatherService weatherService = new WeatherService();
            List<WeatherModel> trimmedWeather = EngagementLogic.TrimWeatherSnapshots(weatherService.QueryWeather());

            // Potentially display an error or warning
            string preMessage = EngagementLogic.WeatherSnapshotsQuantity(trimmedWeather);
            if (!string.IsNullOrEmpty(preMessage))
            {
                System.Console.WriteLine(preMessage);
            }

            // Output the recommended communication method for the remaining weather snapshots
            foreach (WeatherModel weatherSnapShot in trimmedWeather)
            {
                string message = string.Format("{0} - {1}", weatherSnapShot.Start.ToString(), EngagementLogic.CommunicationMethod(weatherSnapShot));
                System.Console.WriteLine(message);
            }
        }
    }
}
