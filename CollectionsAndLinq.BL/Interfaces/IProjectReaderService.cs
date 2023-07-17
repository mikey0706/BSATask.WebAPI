using CollectionsAndLinq.BL.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndLinq.BL.Interfaces
{
    public interface IProjectReaderService
    {
        public Task<List<ProjectDto>> GetAllProjecs();
        public Task<ProjectDto> GetProjectById(int id);
    }
}
