using AutoMapper;
using CollectionsAndLinq.BL.Entities;
using CollectionsAndLinq.BL.Interfaces;
using CollectionsAndLinq.BL.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CollectionsAndLinq.BL.Services.CreateServices
{
    public class ProjectCreateService : IProjectCreateService
    {
        private IDataProvider _provider;
        private IMapper _mapper;

        public ProjectCreateService(IDataProvider provider, IMapper mapper) 
        {
            _provider = provider;
            _mapper = mapper;
        }
        public async Task CreateProject(CreateUpdateProjectDto project) 
        {
            var data = await _provider.GetProjectsAsync();
            data.Add(
                _mapper.Map<Project>(project)
                ); 
        }
        public async Task DeleteProject(int projectId) 
        {
            var data = await _provider.GetProjectsAsync();
            var project = data.FirstOrDefault(p => p.Id == projectId);
            var tasksData = await _provider.GetTasksAsync();

            if (project != null) 
            {
               data.Remove(project);
               var tasks = tasksData.Where(t => t.ProjectId == projectId).ToList();
               
               foreach (var item in tasks) 
               {
                tasksData.Remove(item);
               }
            }
        }
        public async Task UpdateProject(CreateUpdateProjectDto project)
        {
            var data = await _provider.GetProjectsAsync();
            var projectData = data.FirstOrDefault(p => p.Id == project.Id);

            if (projectData != null) 
            {
                var index = data.IndexOf(projectData);
                data.RemoveAt(index);
                data.Insert(index, _mapper.Map<Project>(project));
            }
        }
    }
}
