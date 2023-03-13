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

        private void btnToPage01_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = new Page_01();
        }
        private void btnToPage02_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = new Page_02();
        }
        private void btnOption1_Click(object sender, RoutedEventArgs e)
        {
            
            WindowProduct win1 = new WindowProduct();
            win1.Show();
        }

        private void btnOption2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
