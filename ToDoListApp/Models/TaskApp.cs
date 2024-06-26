// Ignore Spelling: App

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.Models
{
    public class TaskApp
    {
        [Key]
        public int TaskAppId { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Priority { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
