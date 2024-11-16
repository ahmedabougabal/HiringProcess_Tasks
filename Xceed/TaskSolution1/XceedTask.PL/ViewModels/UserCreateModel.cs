using System.ComponentModel.DataAnnotations;

namespace XceedTask.PL.ViewModels
{
    // Types and Validate Data  request From Form Register 
    public class UserCreateModel
    {
  
 
        [Required, MaxLength(15), MinLength(3)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required, EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required, MinLength(6), MaxLength(16)]
        [Display(Name = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, Compare("Password")]
        [Display(Name = "Confirm Password"), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
    }
}