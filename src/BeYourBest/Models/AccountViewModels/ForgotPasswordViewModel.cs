using System.ComponentModel.DataAnnotations;

namespace BeYourBest.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
