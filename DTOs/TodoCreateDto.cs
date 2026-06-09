using System.ComponentModel.DataAnnotations;

namespace TodoApi.DTOs
{
    public class TodoCreateDto
    {
        [Required]
        [MaxLength(255)]
        public required string Title { get; set; }
    }
}
