using AuthApp.BLL.Contracts;
using AuthApp.BLL.Messages;
using AuthApp.Client.Windows.Presentation.MVVM.UserControls.SignUp;
using AuthApp.Client.Windows.Presentation.Resources.Controls;
using AuthApp.Core.Contracts;
using AuthApp.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Client.Windows.Presentation.MVVM.UserControls.Auth
{
    public partial class AuthViewModel : ObservableObject
    {
        public AuthViewModel(
            IDialogService dialogService,
            IUserService userService,
            SignUpControl signUpControl)
        {
            _dialogService = dialogService;
            _userService = userService;
            _signUpControl = signUpControl;

            WeakReferenceMessenger.Default.Register<UserSignedUpMessage>(this, (o, message) =>
            {
                CurrentUser = message.User;
                _dialogService.CloseContent();
            });
        }

        #region Fields

        private IDialogService _dialogService;
        private IUserService _userService;
        private SignUpControl _signUpControl;

        #endregion

        #region Properties

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SignInCommand))]
        private string? _username;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SignInCommand))]
        private string? _password;

        [ObservableProperty]
        private User? _currentUser;

        [ObservableProperty]
        private bool _isSignInFail = false;

        #endregion

        #region Commands

        [RelayCommand(CanExecute = nameof(SignIn_CanExecute))]
        public async Task SignInAsync()
        {
            ArgumentNullException.ThrowIfNull(Username);
            ArgumentNullException.ThrowIfNull(Password);

            bool authSuccess = await _userService.LoginAsync(Username, Password);
            if (authSuccess)
            {
                User? user = await _userService.GetUserByLoginAsync(Username);
                if (user != null)
                {
                    WeakReferenceMessenger.Default.Send(new UserLoggedInMessage(user));
                    CurrentUser = user;
                    IsSignInFail = false;
                    Clear();
                }
                else
                    IsSignInFail = true;
            }
            IsSignInFail = true;
        }
        public bool SignIn_CanExecute
            => !string.IsNullOrWhiteSpace(Username)
                && !string.IsNullOrWhiteSpace(Password);


        [RelayCommand]
        public void SignUp()
        {
            _dialogService.ShowContent(_signUpControl, "Регистрация");
        }

        [RelayCommand]
        public async Task SignOutAsync()
        {
            bool logOutSuccess = await _userService.LogoutAsync();
            if (logOutSuccess)
            {
                WeakReferenceMessenger.Default.Send(new UserLoggedOutMessage());
                CurrentUser = null;
            }
        }

        [RelayCommand]
        public void Clear()
        {
            IsSignInFail = false;
            Username = string.Empty;
            Password = string.Empty;
        }

        #endregion
    }
}
