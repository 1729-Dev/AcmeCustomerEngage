using System;
using System.Collections.Generic;
using System.Text;

// Use our own weather model representation for a given point in time
// rather than the DTOs from openweathermap.org directly.
// This decouples our functionality from theirs such that if they
// change their structure (or if we choose another provider in the future)
// we can simply update our Weather Service layer where we convert to this model
// and the remainder of our code will be insulated from the change.
namespace AcmeCustomerEngage.DataModels
{
    public class WeatherModel
    {
        public DateTime Start { get; set; }

        public float Temperature { get; set; }

        public bool Raining { get; set; }

        public bool Sunny { get; set; }

        public WeatherModel(DateTime Start, float Temperature, bool Sunny = false, bool Raining = false)
        {
            if (Sunny && Raining)
            {
                throw new ArgumentException("Cannot be both sunny and raining");
            }

            this.Start = Start;
            this.Temperature = Temperature;
            this.Sunny = Sunny;
            this.Raining = Raining;
        }
    }
}
