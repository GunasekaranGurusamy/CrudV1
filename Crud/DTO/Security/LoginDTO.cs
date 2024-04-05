using System.ComponentModel.DataAnnotations;

namespace Crud.DTO.Security
{
    public class LoginRequestDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? Expiry { get; set; }
    }

}
