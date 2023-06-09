﻿using System;
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
using System.Text.RegularExpressions;

namespace zPage
{
    /// <summary>
    /// Interaction logic for AddUpdateProperty.xaml
    /// </summary>
    public partial class AddUpdateProperty : Window
    {
        bool isEdit;
        int id;
        decimal oldPrice;
        PropertyRepository repository = new PropertyRepository();
        public AddUpdateProperty(bool isEditOrAdd, int idChange)
        {
            InitializeComponent();
            isEdit = isEditOrAdd;
            id = idChange;
            if (isEdit)
            {
                lbTitle.Content = "Modify a Property";
                Property p = repository.GetPropertyByID(id);
                if (p != null)
                {
                    txtName.Text = p.Name;
                    txtLocation.Text = p.Location;
                    txtArea.Text = (p.Area).ToString();
                    txtPrice.Text = (p.Price).ToString();
                    txtContact.Text = p.Contact;
                    oldPrice = (decimal)p.Price;
                    cbAvai.IsChecked = ("Y" == p.Available ? true : false);
                }
            }
            else
            {
                lbTitle.Content = "Add a Property";
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Regex regexTel = new Regex(@"\(?\+[0-9]{1,3}\)? ?-?[0-9]{1,3} ?-?[0-9]{3,5} ?-?[0-9]{4}( ?-?[0-9]{3})? ?(\w{1,10}\s?\d{1,6})?");
            Match match = regexTel.Match(txtContact.Text);
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
            } else if (txtContact.Text=="")
            {
                MessageBox.Show("Please Input Property's Contact");
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
                decimal.Parse(txtPrice.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please Input Property's Price In Digits");
                check = false;
            }
            if (!match.Success)
            {
                MessageBox.Show("Please Input Property's Contact In Digits");
                check = false;
            }
            if (check)
            {
                Property p = new Property();
                p.Name = txtName.Text;
                p.Location = txtLocation.Text;
                p.Area = double.Parse(txtArea.Text);
                p.Price = decimal.Parse(txtPrice.Text);
                p.Contact = txtContact.Text;
                p.Available = ((bool)cbAvai.IsChecked ? "Y" : "N");
                if (isEdit)
                {
                    if (oldPrice!=p.Price)
                    {
                        PriceHistory ph = new PriceHistory();
                        ph.PropertyId = id;
                        ph.Amount = p.Price;
                        ph.Date = DateTime.Now;
                        repository.addPriceHist(ph);
                    }
                    p.PropertyId = id;
                    repository.UpdateProperty(p);
                    MessageBox.Show("Update Successfully.");
                }
                else
                {
                    repository.InsertProperty(p);
                    Property pIn = repository.getCurrentlyInsert(p);
                    PriceHistory ph = new PriceHistory();
                    ph.PropertyId = pIn.PropertyId;
                    ph.Amount = p.Price;
                    ph.Date = DateTime.Now;
                    repository.addPriceHist(ph);
                    MessageBox.Show("Insert successfully.");
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
