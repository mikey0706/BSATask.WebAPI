using CollectionsAndLinq.BL.Models.Projects;
using CollectionsAndLinq.BL.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndLinq.BL.Interfaces
{
    public interface ITaskCreateService
    {
        public Task CreateTask(CreateUpdateTaskDto task);
        public Task UpdateTask(CreateUpdateTaskDto task);
        public Task DeleteTask(int taskId);
    }
}
