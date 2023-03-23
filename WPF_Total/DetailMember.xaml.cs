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
using DataAccess.ModelShow;
using DataAccess.Repos;

namespace zPage
{
    /// <summary>
    /// Interaction logic for DetailMember.xaml
    /// </summary>
    public partial class DetailMember : Window
    {
        Landlord landlord;
        LandlordRepository landlordRepository = new LandlordRepository();
        PropertyRepository propertyRepository = new PropertyRepository();
        public DetailMember(Landlord land)
        {
            InitializeComponent();
            landlord = land;
            LoadData();
        }
        private void LoadData()
        {
            if (landlord != null)
            {
                lbName.Content = landlord.Name;
                lbCity.Content = landlord.Location;
                lbTel.Content = landlord.Tel;
                lbCitizen.Content = landlord.CitizenId;
                List<PropertyOwnerShow> proList = propertyRepository.getPropertyOwnerListByOwner(landlord.LandlordId);
                dgOwn.ItemsSource = proList;
            }
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddUpdateMember(true, landlord.LandlordId);
            window.Closing += ReloadData;
            window.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to delete this landlord?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                landlordRepository.DeleteLandlord(landlord.LandlordId);
                MessageBox.Show("Delete Successfully");
            }
            this.Close();
        }
        private void ReloadData(object sender, System.ComponentModel.CancelEventArgs e)
        {
            landlord = landlordRepository.GetLandlordByID(landlord.LandlordId);
            LoadData();
        }
    }
}
