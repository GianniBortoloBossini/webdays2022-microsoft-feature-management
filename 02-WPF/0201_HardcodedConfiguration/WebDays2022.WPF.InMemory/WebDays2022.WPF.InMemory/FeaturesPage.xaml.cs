using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
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

namespace WebDays2022.WPF.InMemory
{
    /// <summary>
    /// Interaction logic for Features.xaml
    /// </summary>
    public partial class FeaturesPage : Page
    {
        private readonly IConfigurationRoot configuration;

        public FeaturesPage(IFeatureManager featureManager, IConfigurationRoot configuration)
        {
            InitializeComponent();

            this.configuration = configuration;

            featureEnabled.IsChecked = featureManager.IsEnabledAsync(nameof(FeatureFlags.Feature1)).Result;
            featureDisabled.IsChecked = !featureManager.IsEnabledAsync(nameof(FeatureFlags.Feature1)).Result;
        }

        private void FeatureEnabled_Check(object sender, RoutedEventArgs e)
        {
            // *** SALVIAMO LE MODIFICHE AI FLAG NELLA CONFIGURAZIONE ***
            configuration.Providers.First().Set($"FeatureManagement:{nameof(FeatureFlags.Feature1)}", "True");
            configuration.Reload();
            // **********************************************************
        }

        private void FeatureDisabled_Check(object sender, RoutedEventArgs e)
        {
            // *** SALVIAMO LE MODIFICHE AI FLAG NELLA CONFIGURAZIONE ***
            configuration.Providers.First().Set($"FeatureManagement:{nameof(FeatureFlags.Feature1)}", "False");
            configuration.Reload();
            // **********************************************************
        }
    }
}
