using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskApp.Data;
using TaskApp.Services.ApiModel;

namespace TaskApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        [Route("/Task1")]
        public async Task<IActionResult> GetTask1(DateTime fromDate, DateTime toDate, CancellationToken cancellationToken)
        {

            return Ok(await Task.Run(() =>
             {

                 return Enumerable.Range(1, 5).Select(index => new ApiLogs
                 {
                     EndTime = DateTime.Now,
                     ResponseData = "",
                     Name = "Test",
                     StartTime = DateTime.Now,
                 }).ToList();
             }));
        }

        [HttpGet]
        [Route("/Task2")]
        public async Task<IActionResult> GetTask2(DateTime datetime, CancellationToken cancellationToken)
        {

            return Ok(await Task.Run(() =>
            {
                return new List<WeatherDto>
                {
                    new WeatherDto
                    {
                        City="Riga",
                        MaxTemp =22,
                        MinTemp =17
                    },
                    new WeatherDto
                    {
                        City="Vilinus",
                        MaxTemp =23,
                        MinTemp =16
                    },
                    new WeatherDto
                    {
                        City="Tallin",
                        MaxTemp =24,
                        MinTemp =17
                    },
                    new WeatherDto
                    {
                        City="Berlin",
                        MaxTemp =25,
                        MinTemp =18
                    },
                     new WeatherDto
                    {
                        City="Stockholm",
                        MaxTemp =21,
                        MinTemp =19
                    },
                };
            }));
        }
    }

}

