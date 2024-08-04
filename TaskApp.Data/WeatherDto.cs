using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace TaskApp.Data
{
    public class WeatherDto
    {
        public string City { get; set; }
        public int MaxTemp { get; set; }
        public int MinTemp { get; set; }
    }

}
