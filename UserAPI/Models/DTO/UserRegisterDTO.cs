using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models.DTO
{
    public class UserRegisterDTO:User
    {
        [Required(ErrorMessage = "Password cannot be empty")]
        [MinLength(5, ErrorMessage = " Password should be minimum 5 chars long")]

        public string PasswordString { get; set; }
    }
}
