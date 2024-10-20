using System;
using System.Collections.Generic;
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
        }

        #region Dependency properties

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
