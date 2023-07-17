using CollectionsAndLinq.BL.Entities;
using CollectionsAndLinq.BL.Interfaces;
using Newtonsoft.Json;
using Task = System.Threading.Tasks.Task;

namespace CollectionsAndLinq.BL.Context
{
    public class DataProvider : IDataProvider
    {
        private readonly HttpClient client = new HttpClient();
        private List<Project> _projects;
        private List<Entities.Task> _tasks;
        private List<Team> _teams;
        private List<User> _users;


        public async Task<List<Project>> GetProjectsAsync()
        {
            if (_projects == null) 
            { 
                var data = await Task.Run(() => DataInitializer.Projects);
                _projects = data.ToList();
            }

            return _projects;

        }

        public async Task<List<Entities.Task>> GetTasksAsync()
        {
            if (_tasks == null)
            {
                var data = await Task.Run(() => DataInitializer.Tasks);
                _tasks = data.ToList();
            }

            return _tasks;
        }

        public async Task<List<Team>> GetTeamsAsync()
        {
            if (_teams == null) 
            {
                var data = await Task.Run(() => DataInitializer.Teams);
                _teams = data.ToList();
            }

            return _teams;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            if (_users == null) 
            {
                var data = await Task.Run(() => DataInitializer.Users);
                _users = data.ToList();
            }

            return _users;
        }

    }
}
