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
    /// Interaction logic for OwnerChangeWindow.xaml
    /// </summary>
    public partial class OwnerChangeWindow : Window
    {
        private Property prop;
        LandlordRepository landlordRepos = new LandlordRepository();
        PropertyRepository propRepos = new PropertyRepository();
        private int landLordId;
        List<string> names = new List<String>();
        List<int> ids = new List<int>();
        public OwnerChangeWindow(Property property)
        {
            InitializeComponent();
            prop = property;
            LoadListLandLord();
            lbTitle.Content = lbTitle.Content.ToString().Replace("Name", prop.Name);
        }

        void LoadListLandLord()
        {
            List <Landlord> listLL = (List<Landlord>)landlordRepos.GetLandlord();
            foreach (var ll in listLL)
            {
                if (ll.Name!=null)
                {
                    names.Add(ll.Name);
                    ids.Add(ll.LandlordId);
                }
            }
            landLordId = ids[0];
            cbLandlord.ItemsSource = names;
            cbLandlord.Text = names[0];
        }
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            Landlord ll = new Landlord();
            if (landLordId<1)
            {
                MessageBox.Show("Error");
            } else
            {
                ll.LandlordId = landLordId;
                propRepos.addOwner(ll, prop);
                MessageBox.Show("Add new Owner for this property successfully!");
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbLandlord_DropDownClosed(object sender, EventArgs e)
        {
            landLordId = ids[names.IndexOf(cbLandlord.Text)];
            if (landLordId == -1)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
