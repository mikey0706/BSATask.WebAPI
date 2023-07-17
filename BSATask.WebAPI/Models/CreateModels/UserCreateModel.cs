namespace BSATask.WebAPI.Models.CreateModels
{
    public class UserCreateModel
    {
        public int Id { get; set; }
        public int? TeamId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime RegisteredAt { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
