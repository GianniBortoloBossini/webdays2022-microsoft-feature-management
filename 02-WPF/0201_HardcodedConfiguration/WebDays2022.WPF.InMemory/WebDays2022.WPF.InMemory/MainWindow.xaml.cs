using Microsoft.Extensions.DependencyInjection;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IFeatureManager featureManager;

        public MainWindow(IServiceProvider serviceProvider, IFeatureManager featureManager)
        {
            InitializeComponent();

            this.serviceProvider = serviceProvider;
            this.featureManager = featureManager;
        }

        private void ButtonPage2_Click(object sender, RoutedEventArgs e)
        {
            var featurePage = serviceProvider.GetService<FeaturesPage>();
            Main.Content = featurePage;
        }

        private void ButtonPage1_Click(object sender, RoutedEventArgs e)
        {
            var page1 = serviceProvider.GetService<MyPage>();
            Main.Content = page1;
        }
    }
}
