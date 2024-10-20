using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Reflection;

namespace AuthApp.Client.Windows.Presentation.Resources.Controls
{
    class CustomPasswordBox : System.Windows.Controls.Control
    {
        private IconButton? _btnTogglePasswordVisibility;
        private TextBox? _textBoxVisiblePassword;
        private PasswordBox? _passwordBoxHiddenPassword;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _btnTogglePasswordVisibility = this.Template.FindName("btnTogglePasswordVisibility", this) as IconButton;
            var grid = VisualTreeHelper.GetParent(_btnTogglePasswordVisibility) as Grid;

            _passwordBoxHiddenPassword = grid?.FindName("passwordBoxHiddenPassword") as PasswordBox;
            _textBoxVisiblePassword = grid?.FindName("textBoxVisiblePassword") as TextBox;

            if (_btnTogglePasswordVisibility == null
                || _passwordBoxHiddenPassword == null
                || _textBoxVisiblePassword == null)
                throw new NullReferenceException("Could not find all needed controls inside custom password box template");

            _passwordBoxHiddenPassword.PasswordChanged += (o, e) =>
            {
                Password = _passwordBoxHiddenPassword.Password;
            };

            _btnTogglePasswordVisibility.Click += TogglePasswordVisibility;
        }

        #region Dependency properties

        public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.Register("Password", typeof(string), typeof(CustomPasswordBox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        #endregion




        private void TogglePasswordVisibility(object sender, RoutedEventArgs e)
        {
            ArgumentNullException.ThrowIfNull(_btnTogglePasswordVisibility);
            ArgumentNullException.ThrowIfNull(_passwordBoxHiddenPassword);
            ArgumentNullException.ThrowIfNull(_textBoxVisiblePassword);

            if (_passwordBoxHiddenPassword.Visibility == Visibility.Visible)
            {
                // Show the TextBox (visible password) and hide the PasswordBox
                _textBoxVisiblePassword.Text = _passwordBoxHiddenPassword.Password;
                _textBoxVisiblePassword.Visibility = Visibility.Visible;
                _passwordBoxHiddenPassword.Visibility = Visibility.Collapsed;
                _btnTogglePasswordVisibility.Icon = Material.Icons.MaterialIconKind.EyeOff;
            }
            else
            {
                // Show the PasswordBox (hidden password) and hide the TextBox
                _passwordBoxHiddenPassword.Password = _textBoxVisiblePassword.Text;
                _passwordBoxHiddenPassword.Visibility = Visibility.Visible;
                _textBoxVisiblePassword.Visibility = Visibility.Collapsed;
                _btnTogglePasswordVisibility.Icon = Material.Icons.MaterialIconKind.Eye;
            }
        }
    }
}
