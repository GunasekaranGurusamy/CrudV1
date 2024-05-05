using System.ComponentModel.DataAnnotations;

namespace Crud.API.Model
{
    public class tblUser
    {
        [Key]
        public int Usr_Id { get; set; }
        [Required]
        public string Usr_Name { get; set; }
        [Required]
        public tblMasters Usr_Gender { get; set; }
        [Required]
        public string Usr_Password { get; set; }
        [Required]
        public string Usr_Email { get; set; }
        [Required]
        public tblMasters Usr_Role { get; set; }
        [Required]
        public bool Usr_isActive { get; set; }
    }
}
