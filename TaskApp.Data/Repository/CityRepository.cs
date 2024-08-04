using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Data.Interface;
using TaskApp.Data.Model;

namespace TaskApp.Data.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly TaskAppContext _context;
        public CityRepository(TaskAppContext context) 
        {
            _context = context;
        }
        public async Task Create(City city)
        {
           var checkData = await _context.Cities.Where(x=>x.CityName== city.CityName && x.Date.Equals(DateTime.Now.ToString("yyyy-MM-dd"))).FirstOrDefaultAsync();
            if (checkData != null)
            {
                checkData.Date = DateTime.Now.ToString("yyyy-MM-dd");
                checkData.MaximumTemperature = city.MaximumTemperature;
                checkData.MinimumTemperature = city.MinimumTemperature;
                checkData.LastUpdated = city.LastUpdated;
            }
            else
            {
               await _context.Cities.AddAsync(city);
            }
            await _context.SaveChangesAsync();
           
        }

        public async  Task<List<City>> GetAll(string date)
        {
            return await _context.Cities.Where(x=>x.Date.Equals(date)).ToListAsync();
        }
    }
}
