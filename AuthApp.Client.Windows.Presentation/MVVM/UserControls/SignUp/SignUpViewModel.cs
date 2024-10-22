using AuthApp.BLL.Messages;
using AuthApp.Core.Contracts;
using AuthApp.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AuthApp.Client.Windows.Presentation.MVVM.UserControls.SignUp
{

    public partial class SignUpViewModel : ObservableObject, INotifyDataErrorInfo
    {
        private readonly User _user;
        private readonly IUserService _userService;
        private readonly Dictionary<string, List<string>> _propertyErrors = new();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public SignUpViewModel(IUserService userService)
        {
            _user = new();
            _userService = userService;
        }

        #region Validation Logic

        public bool HasErrors => _propertyErrors.Count > 0;

        public IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !_propertyErrors.ContainsKey(propertyName))
                return null!;
            return _propertyErrors[propertyName];
        }

        private void AddError(string propertyName, string error)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
                _propertyErrors[propertyName] = new List<string>();

            if (!_propertyErrors[propertyName].Contains(error))
            {
                _propertyErrors[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        private void RemoveError(string propertyName, string error)
        {
            if (_propertyErrors.ContainsKey(propertyName) && _propertyErrors[propertyName].Contains(error))
            {
                _propertyErrors[propertyName].Remove(error);
                if (_propertyErrors[propertyName].Count == 0)
                    _propertyErrors.Remove(propertyName);

                OnErrorsChanged(propertyName);
            }
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        #endregion


        #region Properties

        #region Properties with Validation



        public string FirstName
        {
            get => _user.FirstName;
            set
            {
                if (_user.FirstName != value)
                {
                    _user.FirstName = value;
                    ValidateFirstName();
                    OnPropertyChanged();
                    SignUpCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public bool IsValidFirstName => _user.IsValidFirstName;

        private string? _oldFirstNameErrorMessage;
        private void ValidateFirstName()
        {
            var errorMessage = System.Windows.Application.Current.Resources["FirstNameNotValid"] as string;
            if (errorMessage == null)
                return;
            if (!IsValidFirstName)
            {
                AddError(nameof(FirstName), errorMessage);
                _oldFirstNameErrorMessage = errorMessage;
            }
            else
                RemoveError(nameof(FirstName), _oldFirstNameErrorMessage ?? errorMessage);
        }

        public string LastName
        {
            get => _user.LastName;
            set
            {
                if (_user.LastName != value)
                {
                    _user.LastName = value;
                    ValidateLastName();
                    OnPropertyChanged();
                    SignUpCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public bool IsValidLastName => _user.IsValidLastName;

        private string? _oldLastNameErrorMessage;
        private void ValidateLastName()
        {
            var errorMessage = System.Windows.Application.Current.Resources["LastNameNotValid"] as string;
            if (errorMessage == null)
                return;
            if (!IsValidLastName)
            {
                AddError(nameof(LastName), errorMessage);
                _oldLastNameErrorMessage = errorMessage;
            }
            else
                RemoveError(nameof(LastName), _oldLastNameErrorMessage ?? errorMessage);
        }

        public string Email
        {
            get => _user.Email;
            set
            {
                if (_user.Email != value)
                {
                    _user.Email = value;
                    ValidateEmail();
                    OnPropertyChanged();
                    SignUpCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public bool IsValidEmail => _user.IsValidEmail;

        private string? _oldEmailErrorMessage;
        private void ValidateEmail()
        {
            var errorMessage = System.Windows.Application.Current.Resources["EmailNotValid"] as string;
            if (errorMessage == null)
                return;
            if (!IsValidEmail)
            {
                AddError(nameof(Email), errorMessage);
                _oldEmailErrorMessage = errorMessage;
            }
            else
            {
                RemoveError(nameof(Email), _oldEmailErrorMessage ?? errorMessage);
            }
        }

        public string Phone
        {
            get => _user.Phone;
            set
            {
                if (_user.Phone != value)
                {
                    _user.Phone = value;
                    ValidatePhone();
                    OnPropertyChanged();
                    SignUpCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public bool IsValidPhone => _user.IsValidPhone;

        private string? _oldPhoneErrorMessage;
        private void ValidatePhone()
        {
            var errorMessage = System.Windows.Application.Current.Resources["PhoneNotValid"] as string;
            if (errorMessage == null)
                return;
            if (!IsValidPhone)
            {
                AddError(nameof(Phone), errorMessage);
                _oldPhoneErrorMessage = errorMessage;
            }
            else
                RemoveError(nameof(Phone), _oldPhoneErrorMessage ?? errorMessage);
        }

        public string Username
        {
            get => _user.Username;
            set
            {
                if (_user.Username != value)
                {
                    _user.Username = value;
                    ValidateUsername();
                    OnPropertyChanged();
                    SignUpCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public bool IsValidUsername => _user.IsValidUsername;

        private string? _oldUsernameErrorMessage;
        private void ValidateUsername()
        {
            var errorMessage = System.Windows.Application.Current.Resources["UsernameNotValid"] as string;
            if (errorMessage == null)
                return;
            if (!IsValidUsername)
            {
                AddError(nameof(Username), errorMessage);
                _oldUsernameErrorMessage = errorMessage;
            }
            else
                RemoveError(nameof(Username), _oldUsernameErrorMessage ?? errorMessage);
        }

        public string Password
        {
            get => _user.Password;
            set
            {
                if (_user.Password != value)
                {
                    _user.Password = value;
                    ValidatePassword();
                    OnPropertyChanged();
                    SignUpCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public bool IsValidPassword => _user.IsValidPassword;

        private string? _oldPasswordErrorMessage;
        private void ValidatePassword()
        {
            var errorMessage = System.Windows.Application.Current.Resources["PasswordNotValid"] as string;
            if (errorMessage == null)
                return;
            if (!IsValidPassword)
            {
                AddError(nameof(Password), errorMessage);
                _oldPasswordErrorMessage = errorMessage;
            }
            else
                RemoveError(nameof(Password), _oldPasswordErrorMessage ?? errorMessage);
        }

        #endregion

        [ObservableProperty]
        private bool _isSignUpFail;

        #endregion

        #region Commands

        [RelayCommand(CanExecute = nameof(SignUp_CanExecute))]
        public async Task SignUpAsync()
        {
            bool success = await _userService.RegisterUserAsync(_user, loginAfterwards: true);
            if (success)
            {
                User? user = await _userService.GetUserByLoginAsync(_user.Username);
                if (user != null)
                {
                    WeakReferenceMessenger.Default.Send(new UserSignedUpMessage(user));
                    IsSignUpFail = false;
                    Clear();
                }
                else
                    IsSignUpFail = true;
            }
            else
                IsSignUpFail = true;
        }

        public bool SignUp_CanExecute
            => IsValidEmail && IsValidFirstName && IsValidLastName && IsValidPhone && IsValidUsername && IsValidPassword;

        [RelayCommand]
        public void Clear()
        {
            IsSignUpFail = false;
            Username = string.Empty;
            Password = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
        }

        #endregion
    }
}
