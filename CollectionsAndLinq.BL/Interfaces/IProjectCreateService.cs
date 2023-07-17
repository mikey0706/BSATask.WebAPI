using CollectionsAndLinq.BL.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndLinq.BL.Interfaces
{
    public interface IProjectCreateService
    {
        public Task CreateProject(CreateUpdateProjectDto project);
        public Task UpdateProject(CreateUpdateProjectDto project);
        public Task DeleteProject(int projectId);
    }
}
