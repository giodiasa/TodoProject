using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Todo.Entities;

namespace Todo.Models
{
    public class TodoForUpdatingDto
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        public Status Status { get; set; } = Status.Todo;
        [Required]
        public Priority Priority { get; set; } = Priority.Medium;
        [Required]
        [ForeignKey(nameof(IdentityUser))]
        public string UserId { get; set; } = string.Empty;
    }
}
