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
using DataAccess.ModelShow;

namespace zPage
{
    /// <summary>
    /// Interaction logic for DetailProperty.xaml
    /// </summary>
    public partial class DetailProperty : Window
    {
        Property prop;
        string newestLL = "";
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
                lbName.Content = prop.Name;
                lbLocation.Content = prop.Location;
                lbArea.Content = prop.Area.ToString();
                lbPrice.Content = prop.Price.ToString();
                lbContact.Content = prop.Contact;
                cbAvai.IsChecked = ("Y" == prop.Available ? true : false);
                lbFeature.Content = ("" == repos.getFeatures(prop.PropertyId) ? "No features shown yet" : repos.getFeatures(prop.PropertyId));
                List<PropertyOwnerShow> listProp = repos.getOwnerHist(prop);
                int currentOwner = 0;
                foreach (PropertyOwnerShow p in listProp)
                {
                    if (p.OwnEndDate==null)
                    {
                        currentOwner++;
                        break;
                    }
                }
                if (currentOwner==0)
                {
                    btnEndOwner.Visibility = Visibility.Hidden;
                } else
                {
                    btnEndOwner.Visibility = Visibility.Visible;
                }
                listProp.Sort((x, y) => -DateTime.Compare(x.OwnStartDate, y.OwnStartDate));
                dgHist.ItemsSource = listProp;
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

        private void btnChangeOwner_Click(object sender, RoutedEventArgs e)
        {
            var window = new OwnerChangeWindow(prop);
            window.Closing += ReloadData;
            window.ShowDialog();
        }

        private void btnEndOwner_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to end the currently ownership for this property?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                repos.endOwner(prop);
                LoadData();
                MessageBox.Show("End Ownership Successfully");
            }
        }

        private void btnEditFeature_Click(object sender, RoutedEventArgs e)
        {
            var window = new FeatureWindow(prop);
            window.Closing += ReloadData;
            window.ShowDialog();
        }
    }
}
