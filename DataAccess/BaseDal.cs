using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BaseDal
    {
        public StockDataProvider dataProvider { get; set; } = null;

        public SqlConnection connection = null;

        public BaseDal()
        {
            var connectionString = GetConnectionString();
            dataProvider = new StockDataProvider(connectionString);
        }

        public string GetConnectionString()
        {                             
            string connectionString = "Data Source=DESKTOP-PB8AOLR\\VANKA;Initial Catalog=XStore;Persist Security Info=True;User ID=sa;Password=vanka;Encrypt=False";


            return connectionString;
        }
        public void CloseConnection() => dataProvider.CloseConnection(connection);
    }
}
