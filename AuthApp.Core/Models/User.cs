using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AuthApp.Core.Models
{
    public class User
    {
        #region Properties

        public long Id { get; set; }

        public string Username { get; set; } = string.Empty;
        [JsonIgnore]
        public bool IsValidUsername
          => !string.IsNullOrWhiteSpace(Username);

        public string FirstName { get; set; } = string.Empty;

        [JsonIgnore]
        public bool IsValidFirstName
          => !string.IsNullOrWhiteSpace(FirstName);

        public string LastName { get; set; } = string.Empty;
        [JsonIgnore]
        public bool IsValidLastName
            => !string.IsNullOrWhiteSpace(LastName);

        public string Email { get; set; } = string.Empty;
        [JsonIgnore]
        public bool IsValidEmail
            => Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        public string Password { get; set; } = string.Empty;
        [JsonIgnore]
        public bool IsValidPassword
          => !string.IsNullOrWhiteSpace(Password);

        public string Phone { get; set; } = string.Empty;
        [JsonIgnore]
        public bool IsValidPhone
            => Regex.IsMatch(Phone, @"^\+?\d{10,15}$");


        public int UserStatus { get; set; }

        #endregion
    }
}
