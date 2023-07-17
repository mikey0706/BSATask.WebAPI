using CollectionsAndLinq.BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSATask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LINQTasksController : ControllerBase
    {
        private readonly IDataProcessingService _dataProcessingService;


        public LINQTasksController(IDataProcessingService dataProcessingService)
        {
            _dataProcessingService = dataProcessingService;
        }

        [HttpGet(nameof(LinqRoutes.GetTasksCountInProjectsByUserIdAsync))]
        public async Task<ActionResult> ShowTasksCountInProjectsByUserId([FromQuery]int userId) 
        {
            var data = await _dataProcessingService.GetTasksCountInProjectsByUserIdAsync(userId);
            return Ok(data);
        }

        [HttpGet(nameof(LinqRoutes.GetCapitalTasksByUserIdAsync))]

        public async Task<ActionResult> ShowCapitalTasksByUserId([FromQuery] int userId) 
        {
            var data = await _dataProcessingService.GetCapitalTasksByUserIdAsync(userId);
            return Ok(data);
        }
    }
}
