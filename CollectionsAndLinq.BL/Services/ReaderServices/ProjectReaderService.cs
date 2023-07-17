using AutoMapper;
using CollectionsAndLinq.BL.Interfaces;
using CollectionsAndLinq.BL.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndLinq.BL.Services.ReaderServices
{
    public class ProjectReaderService : IProjectReaderService
    {
        private IDataProvider _provider;
        private IMapper _mapper;

        public ProjectReaderService(IDataProvider provider, IMapper mapper) 
        {
            _provider = provider;
            _mapper = mapper;
        }
        public async Task<List<ProjectDto>> GetAllProjecs() 
        {
            var data = await _provider.GetProjectsAsync();
            return _mapper.Map<List<ProjectDto>>(data);
        }
        public async Task<ProjectDto> GetProjectById(int id) 
        {
            var data = await _provider.GetProjectsAsync();
            return _mapper.Map<ProjectDto>(data.FirstOrDefault(p => p.Id == id));
        }
    }
}
