namespace Razor_Pages_Todo.Models.Entities
{
    public class UserTask
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
    }
}
