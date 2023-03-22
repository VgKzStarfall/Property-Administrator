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
using zPage;
using DataAccess.Repos;

namespace MultiPage_A
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOption1_Click(object sender, RoutedEventArgs e)
        {
            MemberWindow win1 = new MemberWindow(new LandlordRepository());
            win1.ShowDialog();
        }

        private void btnOption2_Click(object sender, RoutedEventArgs e)
        {
            var window = new PropertyWindow(new PropertyRepository());
            window.ShowDialog();
        }

        private void btnOption3_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
