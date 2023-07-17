using Bogus;
using CollectionsAndLinq.BL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndLinq.BL.Context
{
    public static class DataInitializer
    {
        private static int TOTAL_COUNT = 20;
        private static Random _rnd = new Random();

        public static List<Team> Teams { get; set; }
        public static List<User> Users{ get; set; }
        public static List<Project> Projects { get; set; }
        public static List<Entities.Task> Tasks { get; set; }

        public static void Seed() 
        {
            Teams = GenerateRandomTeams();
            Users = GenerateRandomUsers(Teams);
            Projects = GenerateRandomProjects(Teams, Users);
            Tasks = GenerateRandomTasks(Projects, Users);
        }

        private static List<Team> GenerateRandomTeams() 
        {

            var fakeTeams = new Faker<Team>()
                    .RuleFor(k => k.Id, f => _rnd.Next(1, 100))
                    .RuleFor(n => n.Name, f => f.Name.FullName())
                    .RuleFor(t => t.CreatedAt, f => f.Date.Between(DateTime.UtcNow.AddYears(-10), DateTime.UtcNow));
            return fakeTeams.Generate(TOTAL_COUNT);
        }
        private static List<User> GenerateRandomUsers(ICollection<Team> teams) 
        {
            var fakeUsers = new Faker<User>()
                    .RuleFor(k => k.Id, f => _rnd.Next(1, 100))
                    .RuleFor(t => t.TeamId, f => f.PickRandom(teams).Id)
                    .RuleFor(n => n.FirstName, f => f.Name.FirstName())
                    .RuleFor(n => n.LastName, f => f.Name.LastName())
                    .RuleFor(m => m.Email, f => f.Internet.Email())
                    .RuleFor(b => b.BirthDay, f => f.Date.Between(DateTime.UtcNow.AddYears(-30), DateTime.UtcNow))
                    .RuleFor(r => r.RegisteredAt, f => f.Date.Between(DateTime.UtcNow.AddYears(-10), DateTime.UtcNow));
            return fakeUsers.Generate(TOTAL_COUNT);
        }
        private static List<Project> GenerateRandomProjects(ICollection<Team> teams, ICollection<User> users) 
        {
             var fakeProjects = new Faker<Project>()
                     .RuleFor(k => k.Id, f => _rnd.Next(1,100))
                     .RuleFor(a => a.AuthorId, f =>f.PickRandom(users).Id)
                     .RuleFor(t => t.TeamId, f => f.PickRandom(teams).Id)
                     .RuleFor(n => n.Name, f => f.Name.FullName())
                     .RuleFor(d => d.Description, f => f.Lorem.Text())
                     .RuleFor(b => b.CreatedAt, f => f.Date.Between(DateTime.UtcNow.AddYears(-10), DateTime.UtcNow))
                     .RuleFor(r => r.Deadline, f => f.Date.Between(DateTime.UtcNow.AddYears(-5), DateTime.MaxValue));
             return fakeProjects.Generate(TOTAL_COUNT);
        }
        
        private static List<Entities.Task> GenerateRandomTasks(ICollection<Project> projects, ICollection<User> users) 
        {
           var fakeTasks = new Faker<Entities.Task>()
                .RuleFor(k => k.Id, f => _rnd.Next(1, 100))
                     .RuleFor(p => p.PerformerId, f => f.PickRandom(users).Id)
                     .RuleFor(p => p.ProjectId, f => f.PickRandom(projects).Id)
                     .RuleFor(n => n.Name, f => f.Name.FullName())
                     .RuleFor(d => d.Description, f => f.Lorem.Text())
                     .RuleFor(s => s.State, f => (TaskState)_rnd.Next(0,3))
                     .RuleFor(b => b.CreatedAt, f => f.Date.Between(DateTime.UtcNow.AddYears(-10), DateTime.UtcNow))
                     .RuleFor(c => c.FinishedAt, f => f.Date.Between(DateTime.UtcNow.AddYears(-1), DateTime.MaxValue));
            return fakeTasks.Generate(TOTAL_COUNT);

        }
    }
}
