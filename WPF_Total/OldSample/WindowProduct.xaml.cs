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
using zPage.OldSample;

namespace MultiPage_A
{
    public partial class WindowProduct : Window
    {
        public WindowProduct()
        {
            InitializeComponent();
        }

        ManageProduct products = new ManageProduct();
        private void Window_Loaded(object sender, RoutedEventArgs e) => LoadProducts();

        private void LoadProducts()
        {
            lvProducts.ItemsSource = products.GetProducts();
        }

        private void btn_Insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = new PRODUCT
                {
                    PRODUCT_DESCRIPTION = txt_Product_Des.Text,
                    PRODUCT_FINISH = txt_Product_Finish.Text,
                    STANDARD_PRICE = int.Parse(txt_Product_Price.Text)
                };
                products.InsertProduct(product);
                LoadProducts();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Product");
            }
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = new PRODUCT
                {
                    PRODUCT_ID = int.Parse(txt_Product_ID.Text),
                    PRODUCT_DESCRIPTION = txt_Product_Des.Text,
                    PRODUCT_FINISH = txt_Product_Finish.Text,
                    STANDARD_PRICE = int.Parse(txt_Product_Price.Text)
                };
                products.UpdateProduct(product);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Product");
            }
        }
        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = new PRODUCT
                {
                    PRODUCT_ID = int.Parse(txt_Product_ID.Text)
                };
                products.DeleteProduct(product);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Category");
            }
        }
    }
}
