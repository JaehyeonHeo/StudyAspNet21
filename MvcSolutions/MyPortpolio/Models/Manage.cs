using System;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class Manage
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="카테고리를 입력하세요!")]
        [DataType(DataType.Text)]
        public string Cate { get; set; }

        [Required(ErrorMessage ="제목을 입력하세요!")]
        [DataType(DataType.Text)]
        public string Subject { get; set; }

        [Required(ErrorMessage ="내용을 입력하세요!")]
        [DataType(DataType.Text)]
        public string Contents { get; set; }

        public DateTime RegDate { get; set; }
    }
}
