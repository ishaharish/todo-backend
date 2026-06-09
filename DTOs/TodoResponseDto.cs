namespace TodoApi.DTOs
{
    public class TodoResponseDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
