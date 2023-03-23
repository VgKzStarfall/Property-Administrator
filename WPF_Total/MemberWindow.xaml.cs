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

namespace zPage
{
    /// <summary>
    /// Interaction logic for MemberWindow.xaml
    /// </summary>
    public partial class MemberWindow : Window
    {
        LandlordRepository landlordRepo;
        PropertyRepository propertyRepository = new PropertyRepository();
        string searchMem;
        public MemberWindow(LandlordRepository landlordRepository)
        {
            InitializeComponent();
            landlordRepo = landlordRepository;
            LoadData();
            searchType.SelectedValue = "Name";
            searchMem = "Name";
        }
        public void LoadData()
        {
            IEnumerable<Landlord> landlords = landlordRepo.GetLandlord();
            List<PropertyOwner> propertyOwners;
            List<Property> properties;
            foreach (Landlord landlord in landlords)
            {
                propertyOwners = propertyRepository.getPropertyOwnerListByOwner(landlord.LandlordId);
                foreach (PropertyOwner propertyOwner in propertyOwners)
                {
                    /*properties = propertyRepository.GetPropertyByID */
                }
            }
            dg.ItemsSource = landlords;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddUpdateMember(false, -1);
            window.Closing += AddUpdateWindow_Closing;
            window.ShowDialog();
        }
        private void AddUpdateWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LoadData();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Landlord? item = dg.SelectedItem as Landlord;
            if (item != null)
            {
                var window = new AddUpdateMember(true, item.LandlordId);
                window.Closing += AddUpdateWindow_Closing;
                window.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Choose A Landlord To Update");
            }
            LoadData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Landlord? item = dg.SelectedItem as Landlord;
            if (item != null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to delete this landlord?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    landlordRepo.DeleteLandlord(item.LandlordId);
                    MessageBox.Show("Delete Successfully");
                }
            }
            else
            {
                MessageBox.Show("Please Choose A Landlord To Delete");
            }
            LoadData();
        }

        private void dg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dg.SelectedItem == null)
            {
                MessageBox.Show("Please Choose A Landlord To View Details");
            }
            else
            {
                Landlord? p = dg.SelectedItem as Landlord;
                if (p.LandlordId != 0)
                {
                    Landlord mem = landlordRepo.GetLandlordByID(p.LandlordId);
                    var window = new DetailMember(mem);
                    window.Closing += AddUpdateWindow_Closing;
                    window.ShowDialog();
                }
            }
        }
        private void searchType_DropDownClosed(object sender, EventArgs e)
        {
            searchMem = searchType.Text;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if("Name".Equals(searchMem))
            {
                dg.ItemsSource = landlordRepo.GetListSearchByName(txtSearch.Text);
            } else if ("City".Equals(searchMem))
            {
                dg.ItemsSource = landlordRepo.GetListSearchByCity(txtSearch.Text);
            }        
        }
    }
}
