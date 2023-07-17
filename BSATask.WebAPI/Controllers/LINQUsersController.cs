using CollectionsAndLinq.BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSATask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LINQUsersController : ControllerBase
    {
        private readonly IDataProcessingService _dataProcessingService;


        public LINQUsersController(IDataProcessingService dataProcessingService)
        {
            _dataProcessingService = dataProcessingService;
        }

        [HttpGet(nameof(LinqRoutes.GetUserInfoAsync))]
        public async Task<ActionResult> ShowUserInfo([FromQuery] int userId) 
        {
            var data = await _dataProcessingService.GetUserInfoAsync(userId);//!
            return Ok(data);
        }

        [HttpGet(nameof(LinqRoutes.GetSortedUsersWithSortedTasksAsync))]
        public async Task<ActionResult> ShowSortedUsersWithSortedTasks() 
        {
            var data = await _dataProcessingService.GetSortedUsersWithSortedTasksAsync();//?
            return Ok(data);
        }
    }
}
