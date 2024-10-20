using AuthApp.Client.Windows.Presentation.MVVM.UserControls.Auth;
using AuthApp.Client.Windows.Presentation.MVVM.UserControls.SignUp;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Client.Windows.Presentation.MVVM
{
    public class ViewModelLocator
    {
        private static IServiceProvider? _serviceProvider;

        public ViewModelLocator() { }

        public ViewModelLocator(IServiceProvider? serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #region ViewModel properties

        public AuthViewModel? AuthViewModel => _serviceProvider?.GetRequiredService<AuthViewModel>();
        public SignUpViewModel? SignUpViewModel => _serviceProvider?.GetRequiredService<SignUpViewModel>();

        #endregion
    }
}
