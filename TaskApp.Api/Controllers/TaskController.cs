using Microsoft.AspNetCore.Mvc;
using TaskApp.Api.Interface;

namespace TaskApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService) 
        {
            _taskService = taskService;
        }
        [HttpGet]
        [Route("/task1")]
        public async Task<IActionResult> GetTask1(DateTime fromDate, DateTime toDate, CancellationToken cancellationToken)
        {
            return Ok(await _taskService.Task1(fromDate, toDate));
        }

        [HttpGet]
        [Route("/task1-blobdata")]
        public async Task<IActionResult> GetTaskDetails(string guid, CancellationToken cancellationToken)
        {
            return Ok(await _taskService.Task1(guid));
        }

        [HttpGet]
        [Route("/task2")]
        public async Task<IActionResult> GetTask2(DateTime datetime, CancellationToken cancellationToken)
        {
            return Ok(await _taskService.Task2(datetime));
        }
    }
}

