using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Application.Dtos
{
    public class TaskCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime DueDate { get; set; }
    }
}
