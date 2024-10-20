﻿using AuthApp.Client.Windows.Presentation.MVVM.Windows.Main;
using AuthApp.Client.Windows.Presentation.MVVM;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using AuthApp.Client.Windows.Presentation.MVVM.UserControls.SignUp;
using AuthApp.Client.Windows.Presentation.MVVM.UserControls.Auth;
using AuthApp.BLL.Contracts;
using AuthApp.Client.Windows.Presentation.Services;
using AuthApp.Core.Contracts;
using AuthApp.DAL.Services;

namespace AuthApp.Client.Windows.Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider? _serviceProvider;
        public ViewModelLocator? ViewModelLocator { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();

            ViewModelLocator = new ViewModelLocator(_serviceProvider);

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            #region Services

            services.AddHttpClient<IUserService, UserService>(client =>
            {
                client.BaseAddress = new Uri("https://petstore.swagger.io");
            });
            services.AddSingleton<IDialogService, DialogService>();

            #endregion


            #region Register Views and ViewModels

            services.AddTransient<MainViewModel>();
            services.AddTransient<MainWindow>();

            services.AddTransient<SignUpControl>();
            services.AddTransient<SignUpViewModel>();

            services.AddTransient<AuthControl>();
            services.AddTransient<AuthViewModel>();

            #endregion
        }
    }

}
