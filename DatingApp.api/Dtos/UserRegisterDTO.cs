using System.ComponentModel.DataAnnotations;

namespace DatingApp.api.Dtos
{
    public class UserRegisterDTO
    {
        [Required]
        public string Username { get; set; }


        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage ="Please enter atleast 4-t8 characters")]
        public string Password { get; set; }
    }
}