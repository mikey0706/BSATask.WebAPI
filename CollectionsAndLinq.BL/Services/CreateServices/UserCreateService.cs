using AutoMapper;
using CollectionsAndLinq.BL.Entities;
using CollectionsAndLinq.BL.Interfaces;
using CollectionsAndLinq.BL.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CollectionsAndLinq.BL.Services.CreateServices
{
    public class UserCreateService : IUserCreateService
    {
        private IDataProvider _provider;
        private IProjectCreateService _projectCreateService;
        private IMapper _mapper;

        public UserCreateService(IDataProvider provider, IProjectCreateService projectCreateService, IMapper mapper)
        {
            _provider = provider;
            _projectCreateService = projectCreateService;
            _mapper = mapper;
        }
        public async Task CreateUser(CreateUpdateUserDto user)
        {
            var data = await _provider.GetUsersAsync();
            data.Add(
                _mapper.Map<User>(user)
                );
        }
        public async Task DeleteUser(int userId)
        {
            var data = await _provider.GetUsersAsync();
            var projectData = await _provider.GetProjectsAsync();
            var user = data.FirstOrDefault(p => p.Id == userId);
            
            
            if (user != null)
            {
                var projects = projectData.Where(p => p.AuthorId == userId).ToList();

                foreach ( var project in projects ) 
                {
                    await _projectCreateService.DeleteProject(project.Id);
                }
                data.Remove(user);
            }
        }
        public async Task UpdateUser(CreateUpdateUserDto user)
        {
            var data = await _provider.GetUsersAsync();
            var userData = data.FirstOrDefault(p => p.Id == user.Id);

            if (userData != null)
            {
                var index = data.IndexOf(userData);
                data.RemoveAt(index);
                data.Insert(index, _mapper.Map<User>(user));
            }
        }
    }
}
