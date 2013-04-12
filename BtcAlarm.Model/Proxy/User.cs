using System;
using System.Collections.Generic;
using System.Linq;

namespace BtcAlarm.Model
{
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        public static string GetToken()
        {
            return Guid.NewGuid().ToString("N");
        }

        public string ConfirmPassword { get; set; }

        public string Captcha { get; set; }

        public bool InRoles(string roles)
        {
            if (string.IsNullOrWhiteSpace(roles))
            {
                return false;
            }

            var rolesArray = roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            return rolesArray
                .Select(role => this.UserRoles.Any(p => string.Compare(p.Role.Code, role, StringComparison.OrdinalIgnoreCase) == 0))
                .Any(hasRole => hasRole);
        }
    }
}
