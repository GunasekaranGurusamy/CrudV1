using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Crud.Model
{
    public class tblUsers
    {
        [Key]
        public int Usr_Id { get; set; }
        [Required]
        public string Usr_Name { get; set; }
        [Required]
        public string Usr_Password { get; set; }
        [Required]
        public string Usr_Email { get; set; }
        [Required]
        public string Usr_Role { get; set; }
        [Required]
        public bool Usr_isActive { get; set; }
    }
}
