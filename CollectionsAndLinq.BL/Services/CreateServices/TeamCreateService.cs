using AutoMapper;
using CollectionsAndLinq.BL.Entities;
using CollectionsAndLinq.BL.Interfaces;
using CollectionsAndLinq.BL.Models.Projects;
using CollectionsAndLinq.BL.Models.Teams;
using CollectionsAndLinq.BL.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CollectionsAndLinq.BL.Services.CreateServices
{
    public class TeamCreateService : ITeamCreateService
    {
        private IDataProvider _provider;
        private IProjectCreateService _projectCreateService;
        private IUserCreateService _userCreateService;
        private IMapper _mapper;

        public TeamCreateService(IDataProvider provider,
            IProjectCreateService projectCreateService,
            IUserCreateService userCreateService,
            IMapper mapper)
        {
            _provider = provider;
            _projectCreateService = projectCreateService;
            _userCreateService = userCreateService;
            _mapper = mapper;
        }
        public async Task CreateTeam(TeamDto team)
        {
            var data = await _provider.GetTeamsAsync();
            data.Add(
                _mapper.Map<Team>(team)
                );
        }
        public async Task DeleteTeam(int teamId) 
        {

            var data = await _provider.GetTeamsAsync();
            var usersData = await _provider.GetUsersAsync();
            var projectData = await _provider.GetProjectsAsync();
            var team = data.FirstOrDefault(p => p.Id == teamId);

            if (team != null)
            {
                var projects = projectData.Where(p => p.TeamId == teamId).ToList();
                var users = usersData.Where(u => u.TeamId == teamId).ToList();

                foreach (var user in users)
                {
                    user.TeamId = null;
                    await _userCreateService.UpdateUser(_mapper.Map<CreateUpdateUserDto>(user));
                }

                foreach (var project in projects)
                {
                    await _projectCreateService.DeleteProject(project.Id);
                }

                
                data.Remove(team);
            }
        }
        public async Task UpdateTeam(TeamDto team) 
        {
            var data = await _provider.GetTeamsAsync();
            var projectData = await _provider.GetProjectsAsync();
            var teamData = data.FirstOrDefault(p => p.Id == team.Id);

            if (teamData != null)
            {
                var index = data.IndexOf(teamData);
                data.RemoveAt(index);
                data.Insert(index, _mapper.Map<Team>(team));
            }
        }
    }
}
