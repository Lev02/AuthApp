using AuthApp.BLL.Contracts;
using AuthApp.Client.Windows.Presentation.MVVM.UserControls.SignUp;
using AuthApp.Client.Windows.Presentation.Resources.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AuthApp.Client.Windows.Presentation.Services
{
    class DialogService : IDialogService
    {
        private Window? _activeWindow;

        public void CloseContent()
        {
            if (_activeWindow != null)
            {
                _activeWindow.Close();
            }
        }

        public void ShowContent(object content, string title)
        {
            _activeWindow = new CustomWindow()
            {
                Padding = new System.Windows.Thickness(20),
                VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
                Content = content,
                Width = 500,
                IsMaximizeButtonVisible = false,
                SizeToContent = SizeToContent.Height,
                Title = title
            };
            _activeWindow.Show();
        }
    }
}
