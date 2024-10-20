using AuthApp.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Client.Windows.Presentation.MVVM.UserControls.SignUp
{
    public class SignUpViewModel : ObservableObject
    {
        private readonly User _user;

        public SignUpViewModel()
        {
            _user = new();
        }

        #region Properties

        public int Id
        {
            get => _user.Id;
            set
            {
                if (_user.Id != value)
                {
                    _user.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string FirstName
        {
            get => _user.FirstName;
            set
            {
                if (_user.FirstName != value)
                {
                    _user.FirstName = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsValidFirstName
            => _user.IsValidFirstName;

        public string LastName
        {
            get => _user.LastName;
            set
            {
                if (_user.LastName != value)
                {
                    _user.LastName = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsValidLastName
            => _user.IsValidLastName;

        public string Email
        {
            get => _user.Email;
            set
            {
                if (_user.Email != value)
                {
                    _user.Email = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsValidEmail
            => _user.IsValidEmail;

        public string Phone
        {
            get => _user.Phone;
            set
            {
                if (_user.Phone != value)
                {
                    _user.Phone = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsValidPhone
            => _user.IsValidPhone;


        public string Username
        {
            get => _user.Username;
            set
            {
                if (_user.Username != value)
                {
                    _user.Username = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsValidUsername
            => _user.IsValidUsername;


        public string Password
        {
            get => _user.Password;
            set
            {
                if (_user.Password != value)
                {
                    _user.Password = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsValidPassword
            => _user.IsValidPassword;

        #endregion
    }
}
