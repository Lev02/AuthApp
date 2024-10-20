using AuthApp.BLL.Contracts;
using AuthApp.Client.Windows.Presentation.MVVM.UserControls.SignUp;
using AuthApp.Client.Windows.Presentation.Resources.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Client.Windows.Presentation.Services
{
    class DialogService : IDialogService
    {
        public void ShowContent(object content, string title)
        {
            var window = new CustomWindow()
            {
                Padding = new System.Windows.Thickness(20),
                Width = 200,
                Content = content,
                IsMaximizeButtonVisible = false,
            };

            window.ShowDialog();
        }
    }
}
