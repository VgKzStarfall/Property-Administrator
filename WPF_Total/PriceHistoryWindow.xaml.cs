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
    /// Interaction logic for PriceHistoryWindow.xaml
    /// </summary>
    public partial class PriceHistoryWindow : Window
    {
        Property prop;
        PropertyRepository repos = new PropertyRepository();
        public PriceHistoryWindow(Property p)
        {
            InitializeComponent();
            prop = p;
            LoadData();
            lbTitle.Content = lbTitle.Content.ToString().Replace("Name", p.Name);
        }

        private void LoadData()
        {
            List<PriceHistory> listHist = repos.getListHistory(prop.PropertyId);
            listHist.Sort((x, y) => -DateTime.Compare((DateTime)x.Date, (DateTime)y.Date));
            dgHist.ItemsSource = listHist;
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
