using EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.Contexts;
using EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.MVVM.ViewModels;
using EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.Services;
using Microsoft.EntityFrameworkCore;
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
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Elias\Downloads\EC-utbildning-webbutvecklare-NET\05-Datalagring\EC05-Databases\EC05_C-sharp-Case_mgmt\EC05_C-sharp-EFC-DI-HOST-MVVM-WPF\Contexts\sql_case_mgmt_db.mdf;Integrated Security=True;Connect Timeout=30";

        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<HomeViewModel>();
                    services.AddSingleton<CreateCaseViewModel>();
                    services.AddSingleton<ListCaseViewModel>();
                    services.AddSingleton<NavigationStore>();
                    services.AddSingleton<ApplicationDbContext>();
                    services.AddSingleton<DateTimeService>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            
            var navigationStore = AppHost!.Services.GetRequiredService<NavigationStore>();
            navigationStore.CurrentViewModel = new HomeViewModel(navigationStore);

            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.DataContext = new MainViewModel(navigationStore);
            mainWindow.Show();
            base.OnStartup(e);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(_connectionString));
        }

        

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }
    }
}
