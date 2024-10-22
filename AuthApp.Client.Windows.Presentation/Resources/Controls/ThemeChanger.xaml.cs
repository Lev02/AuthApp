using AuthApp.BLL.Contracts;
using AuthApp.Client.Windows.Presentation.Properties;
using AuthApp.Core.Enums;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AuthApp.Client.Windows.Presentation.Resources.Controls
{
    /// <summary>
    /// Interaction logic for ThemeChanger.xaml
    /// </summary>
    public partial class ThemeChanger : UserControl, IThemeChangable
    {
        public ThemeChanger()
        {
            DataContext = this;

            if (AppSettings.Default.Theme == ThemeType.Light.ToString())
                CurrentThemeType = ThemeType.Light;
            else
                CurrentThemeType = ThemeType.Dark;

            InitializeComponent();
            PreviewMouseLeftButtonDown += ThemeChanger_MouseLeftButtonDown;
            Loaded += ThemeChanger_Loaded;
        }

        private async void ThemeChanger_Loaded(object sender, RoutedEventArgs e)
        {
            if (CurrentThemeType == ThemeType.Light)
                await ChangeThemeAsync(ThemeType.Light);
        }

        #region CurrentThemeType Dependency property
        public static readonly DependencyProperty CurrentThemeTypeProperty = DependencyProperty.Register(
            name: nameof(CurrentThemeType),
            propertyType: typeof(ThemeType),
            ownerType: typeof(ThemeChanger));

        public ThemeType CurrentThemeType
    {
            get { return (ThemeType)GetValue(CurrentThemeTypeProperty); }
            protected set { SetValue(CurrentThemeTypeProperty, value); }
        }
        #endregion

        private async void ThemeChanger_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            await Application.Current.Dispatcher.InvokeAsync(async () =>
            {
                if (CurrentThemeType == ThemeType.Light)
                    await ChangeThemeAsync(ThemeType.Dark);
                else
                    await ChangeThemeAsync(ThemeType.Light);
            });
        }

        public async Task ChangeThemeAsync(ThemeType themeType)
        {
            var changeThemeAnimationDuration = TimeSpan.FromSeconds(0.5);

            var darkThemeSource = "pack://application:,,,/AuthApp.Client.Windows.Presentation;component/Resources/Styles/Themes/DarkTheme.xaml";
            var lightThemeSource = "pack://application:,,,/AuthApp.Client.Windows.Presentation;component/Resources/Styles/Themes/LightTheme.xaml";

            var oldTheme = new ResourceDictionary();
            var newTheme = new ResourceDictionary();
            if (themeType == ThemeType.Dark)
            {
                oldTheme.Source = new Uri(lightThemeSource);
                newTheme.Source = new Uri(darkThemeSource);
            }
            else
            {
                newTheme.Source = new Uri(lightThemeSource);
                oldTheme.Source = new Uri(darkThemeSource);
            }

            foreach (var key in oldTheme.Keys)
            {
                if (oldTheme[key] is Color oldColor
                    && newTheme[key] is Color newColor
                    && key is string colorKeyStr)
                {
                    var colorAnimation = new ColorAnimation
                    {
                        From = oldColor,
                        To = newColor,
                        Duration = new Duration(changeThemeAnimationDuration),
                        EasingFunction = new SineEase()
                    };

                    var brushKeyStr = colorKeyStr.Replace("Color", "Brush");
                    var frozenBrush = oldTheme[brushKeyStr] as SolidColorBrush;

                    if (frozenBrush != null)
                    {
                        // Создаём новую кисть, которая не будет заморожена
                        var editableBrush = new SolidColorBrush(frozenBrush.Color);
                        editableBrush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);

                        // Обновляем ресурс с новой редактируемой кистью
                        Application.Current.Resources[brushKeyStr] = editableBrush;
                    }
                }
            }

            await Task.Delay(changeThemeAnimationDuration);
            ApplyNewTheme(oldTheme, newTheme);
            AppSettings.Default.Theme = themeType.ToString();
            AppSettings.Default.Save();
            CurrentThemeType = themeType;
        }

        private void ApplyNewTheme(ResourceDictionary oldTheme, ResourceDictionary newTheme)
        {
            Resources.MergedDictionaries.Remove(oldTheme);
            Resources.MergedDictionaries.Add(newTheme);
        }
    }
}
