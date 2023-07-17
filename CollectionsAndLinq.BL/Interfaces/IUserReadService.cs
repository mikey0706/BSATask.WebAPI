using CollectionsAndLinq.BL.Models.Projects;
using CollectionsAndLinq.BL.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndLinq.BL.Interfaces
{
    public interface IUserReadService
    {
        public Task<List<UserDto>> GetAllUsers();
        public Task<UserDto> GetUserById(int id);
    }
}
