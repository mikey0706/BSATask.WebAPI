using AutoMapper;
using BSATask.WebAPI.Models.CreateModels;
using CollectionsAndLinq.BL.Interfaces;
using CollectionsAndLinq.BL.Models.Projects;
using CollectionsAndLinq.BL.Models.Teams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSATask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamCreateService _teamCreateService;
        private readonly ITeamReadService _teamReadService;
        private readonly IMapper _mapper;

        public TeamsController(
            ITeamCreateService teamCreateService,
            ITeamReadService teamReadService,
            IMapper mapper
            )
        {
            _teamCreateService = teamCreateService;
            _teamReadService = teamReadService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTeams()
        {
            var data = await _teamReadService.GetAllTeams();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProjectById([FromRoute] int id)
        {
            var data = await _teamReadService.GetTeamById(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProject([FromBody] TeamDto team)
        {
            await _teamCreateService.CreateTeam(team);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTeam([FromRoute] int id, [FromBody] TeamCreateModel payload)
        {
            payload.Id = id;
            await _teamCreateService.UpdateTeam(_mapper.Map<TeamDto>(payload));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject([FromRoute] int id)
        {
            await _teamCreateService.DeleteTeam(id);
            return Ok();
        }
    }
}
