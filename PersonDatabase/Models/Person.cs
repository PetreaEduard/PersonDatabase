using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonDatabase.Models
{
    public class Person
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Name { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        
        public int Age { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Job { get; set; }

        [StringLength(13, MinimumLength = 12)]
        [Required]
        public string? PhoneNumber { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Adress { get; set; }
        public string? Town { get; set; }
    }
}
