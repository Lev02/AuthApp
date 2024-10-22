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
    /// Interaction logic for LangChanger.xaml
    /// </summary>
    /// <summary>
    /// Interaction logic for LangChanger.xaml
    /// </summary>
    public partial class LangChanger : UserControl, ILangChangable
    {
        public LangChanger()
        {
            DataContext = this;

            if (AppSettings.Default.Lang == LangShortName.en.ToString())
                CurrentLangShortName = LangShortName.en;
            else
                CurrentLangShortName = LangShortName.ru;

            InitializeComponent();
            PreviewMouseLeftButtonDown += LangChanger_MouseLeftButtonDown;
            Loaded += LangChanger_Loaded;
        }

        private void LangChanger_Loaded(object sender, RoutedEventArgs e)
        {
            if (CurrentLangShortName != LangShortName.en)
                ChangeLang(LangShortName.ru);
        }

        #region CurrentLangShortName Dependency property
        public static readonly DependencyProperty CurrentLangShortNameProperty = DependencyProperty.Register(
            name: nameof(CurrentLangShortName),
            propertyType: typeof(LangShortName),
            ownerType: typeof(LangChanger));

        public LangShortName CurrentLangShortName
        {
            get { return (LangShortName)GetValue(CurrentLangShortNameProperty); }
            protected set { SetValue(CurrentLangShortNameProperty, value); }
        }
        #endregion

        private async void LangChanger_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                if (CurrentLangShortName == LangShortName.en)
                    ChangeLang(LangShortName.ru);
                else
                    ChangeLang(LangShortName.en);
            });
        }

        public void ChangeLang(LangShortName langShortName)
        {
            var enLangSource = "pack://application:,,,/AuthApp.Client.Windows.Presentation;component/Resources/Lang/en.xaml";
            var ruLangSource = "pack://application:,,,/AuthApp.Client.Windows.Presentation;component/Resources/Lang/ru.xaml";

            var oldLang = new ResourceDictionary();
            var newLang = new ResourceDictionary();
            if (langShortName == LangShortName.ru)
            {
                oldLang.Source = new Uri(enLangSource);
                newLang.Source = new Uri(ruLangSource);
            }
            else
            {
                oldLang.Source = new Uri(ruLangSource);
                newLang.Source = new Uri(enLangSource);
            }

            ApplyNewLang(oldLang, newLang);
            AppSettings.Default.Lang = langShortName.ToString();
            AppSettings.Default.Save();
            CurrentLangShortName = langShortName;
        }

        private void ApplyNewLang(ResourceDictionary oldLang, ResourceDictionary newLang)
        {
            Application.Current.Resources.MergedDictionaries.Remove(oldLang);
            Application.Current.Resources.MergedDictionaries.Add(newLang);
        }
    }
}
