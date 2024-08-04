using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Data.Model
{
    public class City
    {
        public Guid Id { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
        public long MaximumTemperature { get; set; }
        public long MinimumTemperature { get; set; }
        public string Date { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
