using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BtcAlarm.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using BtcAlarm.Attribute.Validation;

    public class UserView
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "*")]
        [ValidEmail(ErrorMessage = "Invalid format")]
        public string Email { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        [MinLength(5, ErrorMessage = "At least 5 symbols")]
        public string Password { get; set; }

        [Required(ErrorMessage = "*")]
        [Compare("Password", ErrorMessage = "*")]
        public string ConfirmPassword { get; set; }
    }
}