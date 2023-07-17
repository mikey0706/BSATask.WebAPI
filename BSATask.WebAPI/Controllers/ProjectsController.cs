using AutoMapper;
using BSATask.WebAPI.Models.CreateModels;
using CollectionsAndLinq.BL.Interfaces;
using CollectionsAndLinq.BL.Models.Projects;
using Microsoft.AspNetCore.Mvc;

namespace BSATask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectCreateService _projectCreateService;
        private readonly IProjectReaderService _projectReaderService;
        private readonly IMapper _mapper;

        public ProjectsController(
            IProjectCreateService projectCreateService,
            IProjectReaderService projectReaderService,
            IMapper mapper
            ) 
        {
            _projectCreateService = projectCreateService;
            _projectReaderService = projectReaderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProjects() 
        {
            var data = await _projectReaderService.GetAllProjecs();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProjectById([FromRoute]int id) 
        {
            var data = await _projectReaderService.GetProjectById(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProject([FromBody] ProjectCreateModel project) 
        {
            await _projectCreateService.CreateProject(_mapper.Map<CreateUpdateProjectDto>(project));
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProject([FromRoute] int id, [FromBody] ProjectCreateModel payload) 
        {
            payload.Id = id;
            await _projectCreateService.UpdateProject(_mapper.Map<CreateUpdateProjectDto>(payload));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject([FromRoute]int id) 
        {
            await _projectCreateService.DeleteProject(id);
            return Ok();
        }

    }
}
