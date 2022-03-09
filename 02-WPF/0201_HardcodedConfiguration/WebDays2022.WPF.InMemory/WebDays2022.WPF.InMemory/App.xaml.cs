using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WebDays2022.WPF.InMemory
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;
        private readonly IConfigurationRoot configuration;

        public App()
        {
            // *** HARDCODED FEATURE FLAGS CONFIGURATION ***
            var flags = new Dictionary<string, string>
            {
                { $"FeatureManagement:{nameof(FeatureFlags.Feature1)}", "False"}
            };
            // *********************************************

            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(flags);
            configuration = builder.Build();

            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton(configuration);
            services.AddFeatureManagement(configuration);      // <=== REGISTRIAMO IL SERVIZIO
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MyPage>();
            services.AddSingleton<FeaturesPage>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
