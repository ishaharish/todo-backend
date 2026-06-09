namespace TodoApi.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public bool IsCompleted { get; set; } = false;

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
