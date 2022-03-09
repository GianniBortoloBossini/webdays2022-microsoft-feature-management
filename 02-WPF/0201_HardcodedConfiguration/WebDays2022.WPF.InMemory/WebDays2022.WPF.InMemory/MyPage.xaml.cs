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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class MyPage : Page
    {
        private readonly IFeatureManager featureManager;

        public MyPage(IFeatureManager featureManager)
        {
            InitializeComponent();

            this.featureManager = featureManager;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // *** TOGGLE ROUTER ***
            FeatureStatus.Content = "Lo stato della feature è: " + 
                (featureManager.IsEnabledAsync(nameof(FeatureFlags.Feature1)).Result 
                    ? "ABILITATA" 
                    : "DISABILITATA");
            // *********************

        }
    }
}
