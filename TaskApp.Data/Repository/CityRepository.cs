using Microsoft.EntityFrameworkCore;
using TaskApp.Data.Interface;
using TaskApp.Data.Model;

namespace TaskApp.Data.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly TaskDbContext _context;
        public CityRepository(TaskDbContext context)
        {
            _context = context;
        }
        public async Task Create(City city)
        {
            var checkData = await _context.Cities.Where(x => x.CityName == city.CityName).ToListAsync();
            var cityData = checkData.FirstOrDefault(x => x.Date.Equals(DateTime.Now.ToString("yyyy-MM-dd")));
            if (cityData != null)
            {
                cityData.MaximumTemperature = city.MaximumTemperature;
                cityData.MinimumTemperature = city.MinimumTemperature;
                cityData.LastUpdated = city.LastUpdated;
            }
            else
            {
                await _context.Cities.AddAsync(city);
            }
            await _context.SaveChangesAsync();

        }

        public async Task<List<City>> GetAll(string date)
        {
            return await _context.Cities.Where(x => x.Date.Equals(date)).ToListAsync();
        }
    }
}
