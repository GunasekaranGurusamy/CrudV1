using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Crud.DTO.Student
{
    public class StudentDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
