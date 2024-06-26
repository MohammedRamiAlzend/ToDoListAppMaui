// Ignore Spelling: App

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Task>? Tasks { get; set; }
    }
}
