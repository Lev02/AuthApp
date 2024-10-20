using AuthApp.BLL.Contracts;
using AuthApp.Client.Windows.Presentation.MVVM.UserControls.SignUp;
using AuthApp.Client.Windows.Presentation.Resources.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Client.Windows.Presentation.MVVM.UserControls.Auth
{
    public partial class AuthViewModel : ObservableObject
    {
        public AuthViewModel(
            IDialogService dialogService,
            SignUpControl signUpControl)
        {
            _dialogService = dialogService;
            _signUpControl = signUpControl;
        }

        private IDialogService _dialogService;
        private SignUpControl _signUpControl;


        #region Commands

        [RelayCommand]
        public async Task SignInAsync()
        {

        }

        [RelayCommand]
        public void SignUp()
        {
            _dialogService.ShowContent(_signUpControl, "Регистрация");
        }

        [RelayCommand]
        public async Task SignOutAsync()
        {

        }

        #endregion
    }
}
