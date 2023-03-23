using DataAccess.DataAccess;
using DataAccess.Repos;
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

namespace zPage
{
    /// <summary>
    /// Interaction logic for PropertyRevaluation.xaml
    /// </summary>
    public partial class PropertyRevaluation : Window
    {
        PropertyRepository repos;
        string searchProp;
        public PropertyRevaluation(PropertyRepository propertyRepository)
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

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if ("Name".Equals(searchProp))
            {
                dg.ItemsSource = repos.GetListSearchByName(txtSearch.Text);
            }
            else if ("Location".Equals(searchProp))
            {
                dg.ItemsSource = repos.GetListSearchByLocation(txtSearch.Text);
            }
            else if ("Price".Equals(searchProp))
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
            }
            else
            {
                MessageBox.Show("Search ERROR");
            }
        }

        private void searchType_DropDownClosed(object sender, EventArgs e)
        {
            searchProp = searchType.Text;
        }

        private void btnRevaluate_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in repos.GetProperties())
            {
                PriceHistory p = new PriceHistory();
                p.PropertyId = item.PropertyId;
                p.Date = DateTime.Now;
                var number = GetPseudoDoubleWithinRange(-0.05, 0.05);
                item.Price += (item.Price*number);
                repos.UpdateProperty(item);
                p.Amount = item.Price;
                repos.addPriceHist(p);
            }
            LoadData();
        }

        public static decimal GetPseudoDoubleWithinRange(double lowerBound, double upperBound)
        {
            var random = new Random();
            var rDouble = random.NextDouble();
            var rRangeDouble = rDouble * (upperBound - lowerBound) + lowerBound;
            return (decimal)rRangeDouble;
        }
    }
}
