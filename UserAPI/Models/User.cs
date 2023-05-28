using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class User
    {
        [Key]
        public int? UserId { get; set; }
         [MinLength(3, ErrorMessage = " name should be minimum 3 chars long")]
        public string UserName { get; set; }
        public byte[]? Password { get; set; }
        public byte[]? HashKey { get; set; }
        public string Email { get; set; }
        [MinLength(10, ErrorMessage = " Phone Number should be minimum 10 chars long")]
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string UserType { get; set; }
    }
}
