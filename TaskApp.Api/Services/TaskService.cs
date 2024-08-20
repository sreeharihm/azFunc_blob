using TaskApp.Api.Interface;
using TaskApp.Data;
using TaskApp.Data.Interface;
using TaskApp.Services.ApiModel;
using TaskApp.Services.Interface;

namespace TaskApp.Api.Services
{
    public class TaskService : ITaskService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ITableService _tableService;
        private readonly IBlobService _bloblService;
        public TaskService(ICityRepository cityRepository, ITableService tableService, IBlobService bloblService)
        {
            _cityRepository = cityRepository;
            _tableService = tableService;
            _bloblService = bloblService;
        }

        public async Task<List<Logs>> Task1(DateTime fromDate, DateTime toDate)
        {
            var result = new List<Logs>();
            var data = await _tableService.Get(fromDate, toDate);
            if(data!=null)
                result = data.OrderBy(x => x.StartTime).ToList(); ;
            return result;
        }

        public async Task<BlobDetails> Task1(string guid)
        {
            return await _bloblService.Get(guid);
        }

        public async Task<List<WeatherDto>> Task2(DateTime dateTime)
        {
            List<WeatherDto> weatherDtos = new List<WeatherDto>();
            var data =await _cityRepository.GetAll(dateTime.ToString("yyyy-MM-dd"));
            foreach(var d in data) 
            {
                weatherDtos.Add(new WeatherDto{
                    LastUpdatedDate = d.LastUpdated.ToString(),
                    City = d.CityName,
                    MaxTemp = d.MaximumTemperature,
                    MinTemp = d.MinimumTemperature
                });
            }
            return weatherDtos;
        }
    }
}
