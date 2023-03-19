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
    /// Interaction logic for AddUpdateProperty.xaml
    /// </summary>
    public partial class AddUpdateProperty : Window
    {
        bool isEdit;
        int id;
        PropertyRepository repository = new PropertyRepository();
        public AddUpdateProperty(bool isEditOrAdd, int idChange)
        {
            InitializeComponent();
            isEdit = isEditOrAdd;
            id = idChange;
            if (isEdit)
            {
                lbTitle.Content = "Update A Property";
                Property p = repository.GetPropertyByID(id);
                if (p != null)
                {
                    txtName.Text = p.PName;
                    txtLocation.Text = p.PLocation;
                    txtArea.Text = (p.PArea).ToString();
                    txtPrice.Text = (p.PPrice).ToString();
                }
            }
            else
            {
                lbTitle.Content = "Add A Property";
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool check = true;
            if (txtName.Text=="")
            {
                MessageBox.Show("Please Input Property's Name");
                check = false;
            } else if (txtLocation.Text=="")
            {
                MessageBox.Show("Please Input Property's Location");
                check = false;
            } else if (txtArea.Text=="")
            {
                MessageBox.Show("Please Input Property's Area");
                check = false;
            } else if (txtPrice.Text=="")
            {
                MessageBox.Show("Please Input Property's Price");
                check = false;
            }
            try
            {
                double.Parse(txtArea.Text);
            } catch (Exception)
            {
                MessageBox.Show("Please Input Property's Area In Digits");
                check = false;
            }
            try
            {
                int.Parse(txtPrice.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please Input Property's Price In Digits");
                check = false;
            }
            if (check)
            {
                Property p = new Property();
                p.PName = txtName.Text;
                p.PLocation = txtLocation.Text;
                p.PArea = double.Parse(txtArea.Text);
                p.PPrice = int.Parse(txtPrice.Text);
                if (isEdit)
                {
                    p.PropertyId = id;
                    repository.UpdateProperty(p);
                    MessageBox.Show("Update Successfully");
                }
                else
                {
                    repository.InsertProperty(p);
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
