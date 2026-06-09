namespace TodoApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }

        public ICollection<Todo> Todos { get; set; } = new List<Todo>();
    }
}
