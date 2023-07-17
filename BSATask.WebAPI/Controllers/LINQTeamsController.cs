using CollectionsAndLinq.BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSATask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LINQTeamsController : ControllerBase
    {
        private readonly IDataProcessingService _dataProcessingService;

        public LINQTeamsController(IDataProcessingService dataProcessingService)
        {
            _dataProcessingService = dataProcessingService;
        }

        [HttpGet(nameof(LinqRoutes.GetSortedTeamByMembersWithYearAsync))]
        public async Task<ActionResult> ShowSortedTeamByMembersWithYear([FromQuery] int year) 
        {
            var data = await _dataProcessingService.GetSortedTeamByMembersWithYearAsync(year);
            return Ok(data);
        }
    }
}
