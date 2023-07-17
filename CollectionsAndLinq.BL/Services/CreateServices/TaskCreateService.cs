using AutoMapper;
using CollectionsAndLinq.BL.Entities;
using CollectionsAndLinq.BL.Interfaces;
using CollectionsAndLinq.BL.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CollectionsAndLinq.BL.Services.CreateServices
{
    public class TaskCreateService : ITaskCreateService
    {
        private IDataProvider _provider;
        private IMapper _mapper;

        public TaskCreateService(IDataProvider provider, IMapper mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }
        public async Task CreateTask(CreateUpdateTaskDto task) 
        {
            var data = await _provider.GetTasksAsync();
            data.Add(
                _mapper.Map<Entities.Task>(task)
                );
        }
        public async Task DeleteTask(int taskId) 
        {
            var data = await _provider.GetTasksAsync();
            var task = data.FirstOrDefault(p => p.Id == taskId);

            if (task != null)
            {
                data.Remove(task);
            }
        }
        public async Task UpdateTask(CreateUpdateTaskDto task) 
        {
            var data = await _provider.GetTasksAsync();
            var taskData = data.FirstOrDefault(p => p.Id == task.Id);

            if (taskData != null)
            {
                var index = data.IndexOf(taskData);
                data.RemoveAt(index);
                data.Insert(index, _mapper.Map<Entities.Task>(task));
            }
        }
    }
}
