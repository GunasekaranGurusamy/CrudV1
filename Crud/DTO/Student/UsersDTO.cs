using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Crud.DTO.Student
{
    public class UsersDTO
    {
        [Required]
        public string Usr_Name { get; set; }
        [Required]
        public string Usr_Password { get; set; }
        [Required]
        public string Usr_Email { get; set; }
        public string Usr_Role { get; set; }
        public string Usr_State { get; set; }
    }
}
