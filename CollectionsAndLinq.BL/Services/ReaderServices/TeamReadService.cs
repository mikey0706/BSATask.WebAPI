using AutoMapper;
using CollectionsAndLinq.BL.Interfaces;
using CollectionsAndLinq.BL.Models.Projects;
using CollectionsAndLinq.BL.Models.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndLinq.BL.Services.ReaderServices
{
    public class TeamReadService : ITeamReadService
    {
        private IDataProvider _provider;
        private IMapper _mapper;

        public TeamReadService(IDataProvider provider, IMapper mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }
        public async Task<List<TeamDto>> GetAllTeams()
        {
            var data = await _provider.GetTeamsAsync();
            return _mapper.Map<List<TeamDto>>(data);
        }
        public async Task<TeamDto> GetTeamById(int id)
        {
            var data = await _provider.GetTeamsAsync();
            return _mapper.Map<TeamDto>(data.FirstOrDefault(p => p.Id == id));
        }
    }
}
