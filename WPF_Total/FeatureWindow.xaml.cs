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
using System.Windows.Shapes;
using DataAccess.DataAccess;
using DataAccess.Repos;

namespace zPage
{
    /// <summary>
    /// Interaction logic for FeatureWindow.xaml
    /// </summary>
    public partial class FeatureWindow : Window
    {
        private Property prop;
        PropertyRepository repos = new PropertyRepository();
        public FeatureWindow(Property property)
        {
            InitializeComponent();
            prop = property;
            lbTitle.Content = lbTitle.Content.ToString().Replace("Name", prop.Name);
            LoadData();
        }

        private void LoadData()
        {
            dgFeatures.ItemsSource = repos.listFeatures(prop);
        }
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
