using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeCustomerEngage.DTOs
{
    public class ListDTO
    {
        public string Dt { get; set; }

        public MainDTO Main { get; set; }

        public List<WeatherDTO> Weather { get; set; }

        public DateTime Dt_txt { get; set; }
    }
}
