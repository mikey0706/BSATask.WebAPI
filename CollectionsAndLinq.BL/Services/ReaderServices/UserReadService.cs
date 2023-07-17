using AutoMapper;
using CollectionsAndLinq.BL.Interfaces;
using CollectionsAndLinq.BL.Models.Projects;
using CollectionsAndLinq.BL.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndLinq.BL.Services.ReaderServices
{
    public class UserReadService : IUserReadService
    {
        private IDataProvider _provider;
        private IMapper _mapper;

        public UserReadService(IDataProvider provider, IMapper mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> GetAllUsers()
        {
            var data = await _provider.GetUsersAsync();
            return _mapper.Map<List<UserDto>>(data);
        }
        public async Task<UserDto> GetUserById(int id)
        {
            var data = await _provider.GetUsersAsync();
            return _mapper.Map<UserDto>(data.FirstOrDefault(p => p.Id == id));
        }
    }
}
