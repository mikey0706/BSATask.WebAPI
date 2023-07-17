using CollectionsAndLinq.BL.Models.Projects;
using CollectionsAndLinq.BL.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndLinq.BL.Interfaces
{
    public interface ITaskReadService
    {
        public Task<List<TaskDto>> GetAllTasks();
        public Task<TaskDto> GetTaskById(int id);
    }
}
