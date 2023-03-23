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
using DataAccess.Repos;
using DataAccess.DataAccess;
using zPage;

namespace zPage
{
    /// <summary>
    /// Interaction logic for PropertyWindow.xaml
    /// </summary>
    public partial class PropertyWindow : Window
    {
        PropertyRepository repos;
        string searchProp;
        public PropertyWindow(PropertyRepository propertyRepository)
        {
            InitializeComponent();
            repos = propertyRepository;
            LoadData();
            searchType.SelectedValue = "Name";
            searchProp = "Name";
        }

        public void LoadData()
        {
            dg.ItemsSource = repos.GetProperties();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Property? item = dg.SelectedItem as Property;
            if (item != null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to remove this property?", "Removal Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    repos.DeleteProperty(item.PropertyId);
                    MessageBox.Show("Removed.");
                }
            } else
            {
                MessageBox.Show("Which property need updating?");
            }
            LoadData();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Property? item = dg.SelectedItem as Property;
            if (item != null)
            {
                var window = new AddUpdateProperty(true, item.PropertyId);
                window.Closing += AddUpdateWindow_Closing;
                window.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Choose A Property To Update");
            }
            LoadData();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddUpdateProperty(false, -1);
            window.Closing += AddUpdateWindow_Closing;
            window.ShowDialog();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if ("Name".Equals(searchProp))
            {
                dg.ItemsSource = repos.GetListSearchByName(txtSearch.Text);
            } else if ("Location".Equals(searchProp))
            {
                dg.ItemsSource = repos.GetListSearchByLocation(txtSearch.Text);
            } else if ("Area".Equals(searchProp))
            {
                if (txtSearch.Text=="")
                {
                    txtSearch.Text = "0";
                }
                try
                {
                    dg.ItemsSource = repos.GetListSearchByArea(double.Parse(txtSearch.Text));
                } catch (Exception)
                {
                    MessageBox.Show("Please input with digits for Area search");
                }
            } else if ("Price".Equals(searchProp))
            {
                if (txtSearch.Text == "")
                {
                    txtSearch.Text = "0";
                }
                try
                {
                    dg.ItemsSource = repos.GetListSearchByPrice(decimal.Parse(txtSearch.Text));
                }
                catch (Exception)
                {
                    MessageBox.Show("Please input with digits for Price search");
                }
            } else
            {
                MessageBox.Show("Search ERROR");
            }
        }

        private void AddUpdateWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LoadData();
        }

        private void searchType_DropDownClosed(object sender, EventArgs e)
        {
            searchProp = searchType.Text;
        }

        private void dg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dg.SelectedItem == null)
            {
                MessageBox.Show("Please Choose A Property To View Details");
            } else
            {
                Property? p = dg.SelectedItem as Property;
                if (p.PropertyId!=0)
                {
                    Property propCheck = repos.GetPropertyByID(p.PropertyId);
                    var window = new DetailProperty(p);
                    window.Closing += AddUpdateWindow_Closing;
                    window.ShowDialog();
                }
            }
        }
    }
}
