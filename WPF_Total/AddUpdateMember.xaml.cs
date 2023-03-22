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
                    /*txtName.Text = p.CompanyName;
                    txtCity.Text = p.City;
                    txtCountry.Text = p.Country;
                    txtPassword.Text = p.Password;
                    txtEmail.Text = p.Email;*/
                }
            }
            else
            {
                lbTitle.Content = "Add A LandLord";
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(txtEmail.Text);
            bool check = true;
            if (txtName.Text == "")
            {
                MessageBox.Show("Please Input Member's Company Name");
                check = false;
            }
            else if (txtCity.Text == "")
            {
                MessageBox.Show("Please Input Member's City");
                check = false;
            }
            else if (txtCountry.Text == "")
            {
                MessageBox.Show("Please Input Member's Country");
                check = false;
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Please Input Member's Password");
                check = false;
            }
            else if (txtEmail.Text == "" || !match.Success)
            {
                MessageBox.Show("Please Input Email Or Right Format (abc@abc.abc)");
                check = false;
            }
            if (check)
            {
                Landlord p = new Landlord();
               /* p.CompanyName = txtName.Text;
                p.City = txtCity.Text;
                p.Country = txtCountry.Text;
                p.Password = txtPassword.Text;
                p.Email = txtEmail.Text;*/
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
