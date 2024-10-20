using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AuthApp.Core.Models
{
    public class User
    {
        #region Properties

        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public bool IsValidFirstName
          => !string.IsNullOrWhiteSpace(FirstName);

        public string LastName { get; set; } = string.Empty;
        public bool IsValidLastName
            => !string.IsNullOrWhiteSpace(LastName);

        public string Email { get; set; } = string.Empty;
        public bool IsValidEmail
            => Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsValidPhoneNumber
            => Regex.IsMatch(PhoneNumber, @"^\+?\d{10,15}$");

        #endregion
    }
}
