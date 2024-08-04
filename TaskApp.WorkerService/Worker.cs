using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using TaskApp.Services.ApiModel;

namespace TaskApp.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private string _baseUrl;
        private readonly string[] _cities;
        private readonly int _timeout;

        public Worker(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<Worker> logger)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _baseUrl = $"{_configuration["Settings:ApiEndpoint"]}?key={_configuration["Settings:ApiKey"]}";
            _cities = _configuration["Settings:Cities"].Split(",");
            _timeout = Convert.ToInt32(_configuration["Settings:Timeout"]) * 1000;
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
                    _logger.LogInformation($"Fetched data for city:{c}");
                }
                await Task.Delay(_timeout, stoppingToken);
            }
        }
    }
}