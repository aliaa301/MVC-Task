using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Day06.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Max Character = 20 and min Character = 3")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+.[a-zA-Z]{2,4}")]
        public string Email { get; set; }
        [Range(20, 30, ErrorMessage = "Age Must be between 20 and 30")]
        //[DevidedByTwoValidationAttribute(2 , ErrorMessage ="Age must be devided by 2")]
        public int Age { get; set; }
        [ForeignKey("department")]
        public int DeptNo { get; set; }
        public Department department { get; set; }
    }
}
