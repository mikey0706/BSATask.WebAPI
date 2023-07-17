using CollectionsAndLinq.BL.Entities;

namespace BSATask.WebAPI.Models.CreateModels
{
    public class TaskCreateModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int PerformerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskState State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}
