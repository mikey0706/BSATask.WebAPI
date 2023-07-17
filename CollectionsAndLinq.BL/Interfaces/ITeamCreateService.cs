using CollectionsAndLinq.BL.Models.Projects;
using CollectionsAndLinq.BL.Models.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndLinq.BL.Interfaces
{
    public interface ITeamCreateService
    {
        public Task CreateTeam(TeamDto team);
        public Task UpdateTeam(TeamDto team);
        public Task DeleteTeam(int teamId);
    }
}
