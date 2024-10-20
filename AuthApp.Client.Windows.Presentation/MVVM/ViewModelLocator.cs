using AuthApp.Client.Windows.Presentation.MVVM.UserControls.Auth;
using AuthApp.Client.Windows.Presentation.MVVM.UserControls.SignUp;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Client.Windows.Presentation.MVVM
{
    public class ViewModelLocator : ObservableObject
    {
        private static IServiceProvider? _serviceProvider;

        public ViewModelLocator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #region ViewModel properties

        public static AuthViewModel? AuthViewModel => _serviceProvider?.GetRequiredService<AuthViewModel>();
        public static SignUpViewModel? SignUpViewModel => _serviceProvider?.GetRequiredService<SignUpViewModel>();

        #endregion
    }
}
