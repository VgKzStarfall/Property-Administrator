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
    /// Interaction logic for AddUpdateFeature.xaml
    /// </summary>
    public partial class AddUpdateFeature : Window
    {
        private int lineCount = 1;
        private Property prop;
        private bool isEdit;
        private Feature ft;
        PropertyRepository repos = new PropertyRepository();
        public AddUpdateFeature(bool isEdit,Property property, Feature f)
        {
            InitializeComponent();
            prop = property;
            this.isEdit = isEdit;
            lbTitle.Content = lbTitle.Content.ToString().Replace("Name", prop.Name);
            if (isEdit)
            {
                btnMore.Visibility = Visibility.Hidden;
                lbTitle.Content = lbTitle.Content.ToString().Replace("Adding", "Updating");
                ft = f;
                Line1.Text = ft.FeatureDescription;
            }
            btnLess.Visibility = Visibility.Hidden;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!isEdit)
            {
                List<Feature> listFeatures = new List<Feature>();
                for (int i = 1; i <= lineCount; i++)
                {
                    TextBox txt = this.FindName("Line" + i.ToString()) as TextBox;
                    if (txt.Text != "")
                    {
                        Feature f = new Feature();
                        f.PropertyId = prop.PropertyId;
                        f.FeatureDescription = txt.Text;
                        listFeatures.Add(f);
                    }

                }
                if (listFeatures.Count > 0)
                {
                    repos.addFeatures(listFeatures.ToArray());
                    MessageBox.Show("Adding " + lineCount.ToString() + " Features Successfully!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There is no features to add.");
                }
            } else
            {
                if (Line1.Text=="")
                {
                    MessageBox.Show("Feature can not be empty!");
                } else
                {
                    ft.FeatureDescription = Line1.Text;
                    repos.updateFeature(ft);
                    MessageBox.Show("Update Successfully.");
                    this.Close();
                }
            }
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMore_Click(object sender, RoutedEventArgs e)
        {
            if (lineCount==1)
            {
                btnLess.Visibility = Visibility.Visible;
            }
            if (lineCount<5)
            {
                lineCount++;
                TextBox txt = this.FindName("Line" + lineCount.ToString()) as TextBox;
                if (txt!=null)
                {
                    txt.Visibility = Visibility.Visible;
                }
            }
            if (lineCount==5)
            {
                btnMore.Visibility = Visibility.Hidden;
            }
        }

        private void btnLess_Click(object sender, RoutedEventArgs e)
        {
            if (lineCount==2)
            {
                btnLess.Visibility = Visibility.Hidden;
            } 
            if (lineCount>1)
            {
                TextBox txt = this.FindName("Line" + lineCount.ToString()) as TextBox;
                if (txt != null)
                {
                    txt.Text = "";
                    txt.Visibility = Visibility.Hidden;
                }
                lineCount--;
            }
            if (lineCount<5)
            {
                btnMore.Visibility = Visibility.Visible;
            }
        }
    }
}
