using System;
using System.ComponentModel.DataAnnotations;

namespace TodoListWebApp.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "제목을 입력하세요 !")]
        public string Title { get; set; }   
        public bool IsDone { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
