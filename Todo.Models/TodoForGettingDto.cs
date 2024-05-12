using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Todo.Entities;

namespace Todo.Models
{
    public class TodoForGettingDto
    {

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
