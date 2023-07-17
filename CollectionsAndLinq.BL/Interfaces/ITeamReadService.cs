using CollectionsAndLinq.BL.Models.Projects;
using CollectionsAndLinq.BL.Models.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndLinq.BL.Interfaces
{
    public interface ITeamReadService
    {
        public Task<List<TeamDto>> GetAllTeams();
        public Task<TeamDto> GetTeamById(int id);
    }
}
