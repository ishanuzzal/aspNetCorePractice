using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class StudentModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Fill the name")]
        [Column("Student Name", TypeName="varchar(20)")]
        public string Name { get; set; }   
        public int Age { get; set; }

        public string Gender { get; set; }

        
    }
}
