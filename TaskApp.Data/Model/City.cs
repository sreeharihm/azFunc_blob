using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Data.Model
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
        public double MaximumTemperature { get; set; }
        public double MinimumTemperature { get; set; }
        public string Date { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
