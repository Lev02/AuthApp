using AuthApp.BLL.Messages;
using AuthApp.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Client.Windows.Presentation.MVVM.UserControls.UserInfo
{
    public partial class UserInfoViewModel : ObservableObject
    {
        public UserInfoViewModel() 
        {
            WeakReferenceMessenger.Default.Register<UserLoggedInMessage>(this, (o, message) =>
            {
                CurrentUser = message.User;
            });

            WeakReferenceMessenger.Default.Register<UserSignedUpMessage>(this, (o, message) =>
            {
                CurrentUser = message.User;
            });

            WeakReferenceMessenger.Default.Register<UserLoggedOutMessage>(this, (o, message) =>
            {
                CurrentUser = null;
            });
        }

        [ObservableProperty]
        private User? _currentUser;
    }
}
