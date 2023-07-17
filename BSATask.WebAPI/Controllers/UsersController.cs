using AutoMapper;
using BSATask.WebAPI.Models.CreateModels;
using CollectionsAndLinq.BL.Interfaces;
using CollectionsAndLinq.BL.Models.Projects;
using CollectionsAndLinq.BL.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSATask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserCreateService _userCreateService;
        private readonly IUserReadService _userReadService;
        private readonly IMapper _mapper;

        public UsersController(
            IUserCreateService userCreateService,
            IUserReadService userReadService,
            IMapper mapper
            )
        {
            _userCreateService = userCreateService;
            _userReadService = userReadService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            var data = await _userReadService.GetAllUsers();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById([FromRoute] int id)
        {
            var data = await _userReadService.GetUserById(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserCreateModel project)
        {
            await _userCreateService.CreateUser(_mapper.Map<CreateUpdateUserDto>(project));
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser([FromRoute] int id, [FromBody] UserCreateModel payload)
        {
            payload.Id = id;
            await _userCreateService.UpdateUser(_mapper.Map<CreateUpdateUserDto>(payload));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] int id)
        {
            await _userCreateService.DeleteUser(id);
            return Ok();
        }
    }
}
