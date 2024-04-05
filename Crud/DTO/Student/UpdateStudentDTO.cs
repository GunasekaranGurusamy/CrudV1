using System.ComponentModel.DataAnnotations;

namespace Crud.DTO.Student
{
    public class UpdateStudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
