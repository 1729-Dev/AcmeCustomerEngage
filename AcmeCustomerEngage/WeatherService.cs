using AcmeCustomerEngage.DataModels;
using AcmeCustomerEngage.DTOs;
using AcmeCustomerEngage.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcmeCustomerEngage
{
    public class WeatherService
    {
        // Members
        private const string baseUrl = "http://api.openweathermap.org";
        private const string endPoint = "data/2.5/forecast?q=minneapolis,us&units=imperial&APPID=09110e603c1d5c272f94f64305c09436";
        private readonly RestSharpService restSharpService;

        public WeatherService()
        {
            restSharpService = new RestSharpService(baseUrl, endPoint);
        }

        public List<WeatherModel> QueryWeather()
        {
            // Query the weather service
            IRestResponse<WeatherDataDTO> response = restSharpService.GetResponseExpectOK<WeatherDataDTO>();

            // Ensure we have a payload
            if (response.Data is null)
            {
                throw new Exception(string.Format("Weather query returned no data. Response: {0}", response));
            }

            // Ensure the payload has weather data
            if (response.Data.List.Count == 0)
            {
                throw new Exception(string.Format("Weather query data missing weather events. Response: {0}", response));
            }

            // Convert the payload to our weather data model and return
            List<WeatherModel> weather = new List<WeatherModel>();
            foreach (ListDTO weatherListItem in response.Data.List)
            {
                // Ensure exactly one weather detail is present (unsure how to handle multiple at this time)
                if (weatherListItem.Weather is null || weatherListItem.Weather.Count != 1)
                {
                    throw new Exception(string.Format("Weather list item missing weather detail or more than one present. Weather list item: {0}", weatherListItem));
                }

                // Create a new Weather Model to add to the list to return
                WeatherModel weatherItem = new WeatherModel(
                    weatherListItem.Dt_txt,
                    Temperature(weatherListItem),
                    Sunny(weatherListItem.Weather[0]),
                    Raining(weatherListItem.Weather[0])
                );

                weather.Add(weatherItem);
            }

            return weather;
        }

        private bool Raining(WeatherDTO weatherListItem)
        {
            // For now we base our determination of whether or not it is raining on the weather icon
            // Rain will include: shower rain, rain, thunderstorm, snow, mist
            // This is subject to future improvements to use more granular Weather Condition Codes instead of icons
            // and as determined by customer feedback
            if (string.IsNullOrEmpty(weatherListItem.Icon))
            {
                throw new Exception(string.Format("Unable to determine if it is raining. Weather list item: {0}", weatherListItem));
            }

            List<string> rainIconPrefixes = new List<string>()
            {
                "09", "10", "11", "13", "50"
            };

            return rainIconPrefixes.Contains(weatherListItem.Icon.Substring(0, 2));
        }

        private bool Sunny(WeatherDTO weatherListItem)
        {
            // For now we base our determination of whether or not it is sunny on the weather icon
            // Sunny will include: clear sky, few clouds
            // This is subject to future improvements to use more granular Weather Condition Codes instead of icons
            // and as determined by customer feedback

            if (string.IsNullOrEmpty(weatherListItem.Icon))
            {
                throw new Exception(string.Format("Unable to determine if it is sunny. Weather list item: {0}", weatherListItem));
            }

            List<string> sunnyIcons = new List<string>()
            {
                "01d", "02d"
            };

            return sunnyIcons.Contains(weatherListItem.Icon.ToLower());
        }

        private float Temperature(ListDTO weatherListItem)
        {
            // Ensure temperature container itself is present
            if (weatherListItem.Main is null)
            {
                throw new Exception(string.Format("Unable to determine Temperature. Weather list item: {0}", weatherListItem));
            }

            return weatherListItem.Main.Temp;
        }
    }
}
