using BSATask.WebAPI.Models.ReadModel;
using CollectionsAndLinq.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BSATask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LINQProjectsController : ControllerBase
    {
        private readonly IDataProcessingService _dataProcessingService;

        public LINQProjectsController(IDataProcessingService dataProcessingService) 
        {
            _dataProcessingService = dataProcessingService;
        }

        [HttpGet(nameof(LinqRoutes.GetSortedFilteredPageOfProjectsAsync))]
        public async Task<ActionResult> ShowSortedFilteredPageOfProjectsAsync([FromQuery] SortedFilteredPagedModel model) 
        {
            var data = await _dataProcessingService.GetSortedFilteredPageOfProjectsAsync(model.PageModel, model.FilterModel, model.SortingModel);
            return Ok(data);
        }

        [HttpGet(nameof(LinqRoutes.GetProjectsByTeamSizeAsync))]
        public async Task<ActionResult> ShowProjectsByTeamSize([FromQuery] int size)
        {
            var data = await _dataProcessingService.GetProjectsByTeamSizeAsync(size);
            List<TeamSizeProjectInfo> output = data.Select(d => new TeamSizeProjectInfo 
            {
            Id = d.Id,
            Name = d.Name,
            }).ToList();

            return Ok(output);
        }

        [HttpGet(nameof(LinqRoutes.GetProjectsInfoAsync))]
        public async Task<ActionResult> ShowProjectsInfo() 
        {
            var data = await _dataProcessingService.GetProjectsInfoAsync();
            return Ok(data);
        }
    }
}
