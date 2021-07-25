using fabledatalink.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using System.Windows;
using MediatR;

namespace fabledatalink
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public static IServiceProvider ServiceProvider { get; private set; } = null!;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                {
                    ConfigureServices(services);
                })
                .Build();

            ServiceProvider = _host.Services;
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<FableDataLinkWindow>();

            ConfigureViewModels(services);

            services.AddMediatR(typeof(App).GetTypeInfo().Assembly);
        }

        private static void ConfigureViewModels(IServiceCollection services)
        {
            services.AddSingleton<FableDataLinkViewModel>();
            services.AddSingleton<ProviderViewModel>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            var mainWindow = _host.Services.GetRequiredService<FableDataLinkWindow>();

            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }

            base.OnExit(e);
        }
    }
}
