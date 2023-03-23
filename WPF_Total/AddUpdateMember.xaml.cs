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
using System.Text.RegularExpressions;

namespace zPage
{
    /// <summary>
    /// Interaction logic for AddUpdateMember.xaml
    /// </summary>
    public partial class AddUpdateMember : Window
    {
        bool isEdit;
        int id;
        LandlordRepository landlordRepository = new LandlordRepository();
        public AddUpdateMember(bool isEditOrAdd, int idChange)
        {
            InitializeComponent();
            isEdit = isEditOrAdd;
            id = idChange;
            if (isEdit)
            {
                lbTitle.Content = "Update A LandLord";
                Landlord p = landlordRepository.GetLandlordByID(idChange);
                if (p != null)
                {
                    txtName.Text = p.Name;
                    txtLocation.Text = p.Location;
                    txtTel.Text = p.Tel;
                    txtCitizenId.Text = p.CitizenId;
                }
            }
            else
            {
                lbTitle.Content = "Add A LandLord";
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Regex regexTel = new Regex(@"\(?\+[0-9]{1,3}\)? ?-?[0-9]{1,3} ?-?[0-9]{3,5} ?-?[0-9]{4}( ?-?[0-9]{3})? ?(\w{1,10}\s?\d{1,6})?");
            Regex regexId = new Regex(@"^[0-9]{12}$");
            Regex regexName = new Regex(@"^([a-zA-Z]{1,30}\D+){1,10}$");
            Match match = regexTel.Match(txtTel.Text);
            Match matchCitizenId = regexId.Match(txtCitizenId.Text);
            Match matchName = regexName.Match(txtName.Text);
            bool check = true;
            if (txtName.Text == "" || !matchName.Success)
            {
                MessageBox.Show("Please Input Landlord's Name");
                check = false;
            }
            else if (txtLocation.Text == "")
            {
                MessageBox.Show("Please Input Landlord's Location");
                check = false;
            }
            else if (txtTel.Text == "" || !match.Success)
            {
                MessageBox.Show("Please Input Landlord's Phone Correctly");
                check = false;
            }
            else if (txtCitizenId.Text == "" || !matchCitizenId.Success)
            {
                MessageBox.Show("Please Input Landlord's Citizen ID Correctly");
                check = false;
            }
            if (check)
            {
                Landlord p = new Landlord();
                p.Name = txtName.Text;
                p.Location = txtLocation.Text;
                p.CitizenId = txtCitizenId.Text;
                p.Tel = txtTel.Text;
                if (isEdit)
                {
                    p.LandlordId = id;
                    landlordRepository.UpdateLandlord(p);
                    MessageBox.Show("Update Successfully");
                }
                else
                {
                    landlordRepository.InsertLandlord(p);
                    MessageBox.Show("Insert successfully");
                }
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
