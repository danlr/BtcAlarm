namespace BtcAlarm.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using BtcAlarm.Attribute.Validation;

    public class LoginView
    {
        [Required(ErrorMessage = "*")]
        [ValidEmail(ErrorMessage = "Invalid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        public string Password { get; set; }

        public bool IsPersistent { get; set; }
    }
}