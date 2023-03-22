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
    /// Interaction logic for DetailProperty.xaml
    /// </summary>
    public partial class DetailProperty : Window
    {
        Property prop;
        PropertyRepository repos = new PropertyRepository();
        public DetailProperty(Property p)
        {
            InitializeComponent();
            prop = p;
            LoadData();
        }

        private void LoadData()
        {
            if (prop!=null)
            {
               /* lbName.Content = prop.PName;
                lbLocation.Content = prop.PLocation;
                lbArea.Content = prop.PArea.ToString();
                lbPrice.Content = prop.PArea.ToString();*/
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddUpdateProperty(true, prop.PropertyId);
            window.Closing += ReloadData;
            window.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to delete this property?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                repos.DeleteProperty(prop.PropertyId);
                MessageBox.Show("Delete Successfully");
            }
            this.Close();
        }

        private void ReloadData(object sender, System.ComponentModel.CancelEventArgs e)
        {
            prop = repos.GetPropertyByID(prop.PropertyId);
            LoadData();
        }
    }
}
