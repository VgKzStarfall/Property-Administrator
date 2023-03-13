using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace zPage.OldSample
{
    public record PRODUCT
    {
        public int PRODUCT_ID { get; set; }
        public string PRODUCT_DESCRIPTION { get; set; }
        public string PRODUCT_FINISH { get; set; }
        public int STANDARD_PRICE { get; set; }

    }

    public class ManageProduct
    {
        SqlConnection connection;
        SqlCommand command;
        string ConnectionString = "Data Source=DESKTOP-PB8AOLR\\VANKA;Initial Catalog=ORDER_MANAGEMENT;Persist Security Info=True;User ID=sa;Password=vanka;Encrypt=False";

        public List<PRODUCT> GetProducts()
        {
            List<PRODUCT> Products = new List<PRODUCT>();
            connection = new SqlConnection(ConnectionString);
            string SQL = "Select PRODUCT_ID, PRODUCT_DESCRIPTION, PRODUCT_FINISH, STANDARD_PRICE from PRODUCT";
            command = new SqlCommand(SQL, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        Products.Add(new PRODUCT
                        {
                            PRODUCT_ID = reader.GetInt32("PRODUCT_ID"),
                            PRODUCT_DESCRIPTION = reader.GetString("PRODUCT_DESCRIPTION"),
                            PRODUCT_FINISH = reader.GetString("PRODUCT_FINISH"),
                            STANDARD_PRICE = reader.GetInt32("STANDARD_PRICE")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return Products;
        }

        //Insert
        public void InsertProduct(PRODUCT product)
        {
            connection = new SqlConnection(ConnectionString);
            command = new SqlCommand("Insert PRODUCT values (@PRODUCT_DESCRIPTION,@PRODUCT_FINISH,@STANDARD_PRICE)", connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        //Update
        public void UpdateProduct(PRODUCT product)
        {
            connection = new SqlConnection(ConnectionString);
            string SQL = "Update PRODUCT set PRODUCT_DESCRIPTION=@PRODUCT_DESCRIPTION,PRODUCT_FINISH=@PRODUCT_FINISH,STANDARD_PRICE=@STANDARD_PRICE where PRODUCT_ID=@PRODUCT_ID";
            command = new SqlCommand(SQL, connection);
            command.Parameters.AddWithValue("@PRODUCT_ID", product.PRODUCT_ID);
            command.Parameters.AddWithValue("@PRODUCT_DESCRIPTION", product.PRODUCT_DESCRIPTION);
            command.Parameters.AddWithValue("@PRODUCT_FINISH", product.PRODUCT_FINISH);
            command.Parameters.AddWithValue("@STANDARD_PRICE", product.STANDARD_PRICE);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        //Delete
        public void DeleteProduct(PRODUCT product)
        {
            connection = new SqlConnection(ConnectionString);
            string SQL = "Delete PRODUCT where PRODUCT_ID=@PRODUCT_ID";
            command = new SqlCommand(SQL, connection);
            command.Parameters.AddWithValue("@PRODUCT_ID", product.PRODUCT_ID);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        //
    }
}
