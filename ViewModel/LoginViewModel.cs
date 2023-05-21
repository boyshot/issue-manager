using System.ComponentModel.DataAnnotations;

namespace WebIssueManagementApp.ViewModel
{
  public class LoginViewModel
  {
    [Required(ErrorMessage = "The email must be informed!")]
    [EmailAddress(ErrorMessage = "The email is Invalid!")]
    [Display(Name = "E-mail")]
    public string Email { get; set; }


    [Required(ErrorMessage = "The password must be informed!")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Must be a minimum of 6 characters and a maximum of 100 characters")]
    public string Password { get; set; }
  }
}
