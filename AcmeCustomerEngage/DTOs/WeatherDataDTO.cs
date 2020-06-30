using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeCustomerEngage.DTOs
{
    public class WeatherDataDTO
    {
        public CityDTO City { get; set; }

        public List<ListDTO> List { get; set; }
    }
}
