using EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.MVVM.ViewModels;
using EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EC05_C_sharp_EFC_DI_HOST_MVVM_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<HomeViewModel>();
                    services.AddSingleton<NavigationStore>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var navigationStore = AppHost!.Services.GetRequiredService<NavigationStore>();
            

            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm.DataContext = new MainViewModel(navigationStore);
            startupForm.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }
    }
}
