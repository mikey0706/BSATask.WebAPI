using AutoMapper;
using BSATask.WebAPI.Models.CreateModels;
using CollectionsAndLinq.BL.Interfaces;
using CollectionsAndLinq.BL.Models.Projects;
using CollectionsAndLinq.BL.Models.Tasks;
using CollectionsAndLinq.BL.Services.CreateServices;
using CollectionsAndLinq.BL.Services.ReaderServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSATask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskCreateService _taskCreateService;
        private readonly ITaskReadService _taskReaderService;
        private readonly IMapper _mapper;

        public TasksController(
            ITaskCreateService taskCreateService,
            ITaskReadService taskReaderService,
            IMapper mapper
            )
        {
            _taskCreateService = taskCreateService;
            _taskReaderService = taskReaderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTasks()
        {
            var data = await _taskReaderService.GetAllTasks();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProjectById([FromRoute] int id)
        {
            var data = await _taskReaderService.GetTaskById(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProject([FromBody] TaskCreateModel project)
        {
            await _taskCreateService.CreateTask(_mapper.Map<CreateUpdateTaskDto>(project));
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProject([FromRoute] int id, [FromBody] TaskCreateModel payload)
        {
            payload.Id = id;
            await _taskCreateService.UpdateTask(_mapper.Map<CreateUpdateTaskDto>(payload));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject([FromRoute] int id)
        {
            await _taskCreateService.DeleteTask(id);
            return Ok();
        }
    }
}
