using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AuthApp.Client.Windows.Presentation.Resources.Controls
{
    public class CustomWindow : Window
    {
        public CustomWindow() : base()
        {
            this.Style = Application.Current.Resources["CustomWindowStyle"] as Style;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var gridTitleBar = this.Template.FindName("gridTitleBar", this) as Grid;
            var btnMinimize = this.Template.FindName("btnMinimize", this) as Button;
            var btnMaximize = this.Template.FindName("btnMaximize", this) as Button;
            var btnClose = this.Template.FindName("btnClose", this) as Button;

            if (gridTitleBar == null
                || btnMinimize == null
                || btnMaximize == null
                || btnClose == null)
                throw new NullReferenceException("Could not find all needed controls inside custom window template");

            gridTitleBar.MouseLeftButtonDown += gridTitleBar_MouseLeftButtonDown;
            btnMinimize.Click += btnMinimize_Click;
            btnMaximize.Click += btnMaximize_Click;
            btnClose.Click += btnClose_Click;
        }


        #region Dependency properties

        #region IsMinimizeButtonVisible Depedency property
        public static readonly DependencyProperty IsMinimizeButtonVisibleProperty = DependencyProperty.Register(
            name: nameof(IsMinimizeButtonVisible),
            propertyType: typeof(bool),
            ownerType: typeof(CustomWindow),
            typeMetadata: new PropertyMetadata(defaultValue: true));

        public bool IsMinimizeButtonVisible
        {
            get { return (bool)GetValue(IsMinimizeButtonVisibleProperty); }
            set { SetValue(IsMinimizeButtonVisibleProperty, value); }
        }
        #endregion


        #region IsMaximizeButtonVisible Depedency property
        public static readonly DependencyProperty IsMaximizeButtonVisibleProperty = DependencyProperty.Register(
            name: nameof(IsMaximizeButtonVisible),
            propertyType: typeof(bool),
            ownerType: typeof(CustomWindow),
            typeMetadata: new PropertyMetadata(defaultValue: true));

        public bool IsMaximizeButtonVisible
        {
            get { return (bool)GetValue(IsMaximizeButtonVisibleProperty); }
            set { SetValue(IsMaximizeButtonVisibleProperty, value); }
        }
        #endregion


        #endregion


        #region Event handlers

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            ToggleMaximizeRestore();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void gridTitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                }
            }
            else
            {
                this.DragMove();
            }
        }


        #endregion


        #region Utility methods

        private void ToggleMaximizeRestore()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        #endregion
    }
}
