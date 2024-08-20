using Newtonsoft.Json;
using TaskApp.Data.Interface;
using TaskApp.Data.Model;
using TaskApp.Data.Repository;
using TaskApp.Services.ApiModel;

namespace TaskApp.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ICityRepository _cityRepository;
        private string _baseUrl;
        private readonly string[] _cities;
        private readonly int _timeout;

        public Worker(IHttpClientFactory httpClientFactory, IConfiguration configuration,IServiceScopeFactory serviceScopeFactory, ILogger<Worker> logger)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _baseUrl = $"{_configuration["Settings:ApiEndpoint"]}?key={_configuration["Settings:ApiKey"]}";
            _cities = _configuration["Settings:Cities"].Split(",");
            _timeout = Convert.ToInt32(_configuration["Settings:Timeout"]) * 1000;
            var scope = serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TaskDbContext>();
            context.ConnectionString = _configuration.GetConnectionString("TaskDbConnection").ToString();
            _cityRepository = new CityRepository(context);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                foreach (var c in _cities)
                {
                    _logger.LogInformation($"Fetching data for city:{c}");
                    var client = _httpClientFactory.CreateClient();
                    var _url = _baseUrl + $"&q={c}&dt={DateTime.Now.ToString("yyyy-MM-dd")}";
                    var apiResponse = await client.GetStringAsync(_url);
                    var result = JsonConvert.DeserializeObject<Weather>(apiResponse);
                    await _cityRepository.Create(new City
                    {
                        Id = Guid.NewGuid(),
                        CityName = result.Location.Name,
                        Country = result.Location.Country,
                        Date = Convert.ToDateTime(result.Location.Localtime).ToString("yyyy-MM-dd"),
                        MaximumTemperature = result.Forecast.Forecastday[0].Day.MaxtempC,
                        MinimumTemperature = result.Forecast.Forecastday[0].Day.MintempC,
                        LastUpdated = DateTime.Now
                    });
                    _logger.LogInformation($"Fetched data for city:{c}");
                }
                await Task.Delay(_timeout, stoppingToken);
            }
        }
    }
}