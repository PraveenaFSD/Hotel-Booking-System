using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models.DTO
{
    public class UserRegisterDTO:User
    {
        [Required(ErrorMessage = "Password cannot be empty")]
        public string PasswordString { get; set; }
    }
}
