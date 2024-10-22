using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AuthApp.Core.Enums;
using CommunityToolkit.Mvvm.Input;
using Material.Icons;
using Material.Icons.WPF;

namespace AuthApp.Client.Windows.Presentation.Resources.Controls
{
    /// <summary>
    /// Interaction logic for IconButton.xaml
    /// </summary>
    public partial class IconButton : Button
    {
        public IconButton()
        {
            InitializeComponent();
            UpdateApperance();

            var dpd = DependencyPropertyDescriptor.FromProperty(Button.CommandProperty, typeof(Button));
            if (dpd != null)
            {
                dpd.AddValueChanged(this, OnCommandChanged);
            }
        }

        private void OnCommandChanged(object? sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null
                && button.Command is AsyncRelayCommand relayCommand)
            {
                AsyncRelayCommand = relayCommand;
            }
        }


        #region Dependency properties

        #region Async Relay Command Dependency property
        public static readonly DependencyProperty AsyncRelayCommandProperty = DependencyProperty.Register(
            name: nameof(AsyncRelayCommand),
            propertyType: typeof(AsyncRelayCommand),
            ownerType: typeof(IconButton),
            typeMetadata: new PropertyMetadata(defaultValue: null));

        public AsyncRelayCommand? AsyncRelayCommand
        {
            get { return (AsyncRelayCommand?)GetValue(AsyncRelayCommandProperty); }
            private set { SetValue(AsyncRelayCommandProperty, value); }
        }
        #endregion

        #region Text Dependency Property
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            name: nameof(Text), 
            propertyType: typeof(string), 
            ownerType: typeof(IconButton), 
            typeMetadata: new PropertyMetadata(defaultValue: null));

        public string? Text
        {
            get { return (string?)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        #endregion

        #region Text Progress Dependency Property
        public static readonly DependencyProperty TextProgressProperty = DependencyProperty.Register(
            name: nameof(TextProgress),
            propertyType: typeof(string),
            ownerType: typeof(IconButton),
            typeMetadata: new PropertyMetadata(defaultValue: null));

        public string? TextProgress
        {
            get { return (string?)GetValue(TextProgressProperty); }
            set { SetValue(TextProgressProperty, value); }
        }
        #endregion

        #region Icon Dependency Property
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            name: nameof(Icon), 
            propertyType: typeof(MaterialIconKind?), 
            ownerType: typeof(IconButton), 
            typeMetadata: new PropertyMetadata(defaultValue: null)
        );

        public MaterialIconKind? Icon
        {
            get { return (MaterialIconKind?)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        #endregion

        #region Appearance Dependency Property
        public static readonly DependencyProperty AppearanceProperty = DependencyProperty.Register(
            name: nameof(Appearance),
            propertyType: typeof(ButtonAppearance),
            ownerType: typeof(IconButton),
            typeMetadata: new PropertyMetadata(
                defaultValue: ButtonAppearance.Primary,
                propertyChangedCallback: new PropertyChangedCallback(OnApperancePropertyChanged)));

        private static void OnApperancePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not IconButton iconButton)
                return;
            iconButton.UpdateApperance();
        }

        public ButtonAppearance Appearance
        {
            get { return (ButtonAppearance)GetValue(AppearanceProperty); }
            set { SetValue(AppearanceProperty, value); }
        }

        public void UpdateApperance()
        {
            var resource = Application.Current.Resources[$"{Appearance}ButtonStyle"] as Style;
            btnMain.Style = resource;
        }

        #endregion

        #endregion
    }
}
