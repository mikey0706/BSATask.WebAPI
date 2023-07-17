using AutoMapper;
using CollectionsAndLinq.BL.Interfaces;
using CollectionsAndLinq.BL.Models.Projects;
using CollectionsAndLinq.BL.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndLinq.BL.Services.ReaderServices
{
    public class TaskReadService : ITaskReadService
    {
        private IDataProvider _provider;
        private IMapper _mapper;

        public TaskReadService(IDataProvider provider, IMapper mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }
        public async Task<List<TaskDto>> GetAllTasks()
        {
            var data = await _provider.GetTasksAsync();
            return _mapper.Map<List<TaskDto>>(data);
        }
        public async Task<TaskDto> GetTaskById(int id) 
        {
            var data = await _provider.GetTasksAsync();
            return _mapper.Map<TaskDto>(data.FirstOrDefault(p => p.Id == id));
        }
    }
}
