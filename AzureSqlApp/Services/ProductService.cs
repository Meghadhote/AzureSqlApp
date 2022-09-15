using AzureSqlApp.Models;
using System.Data.SqlClient;
namespace AzureSqlApp.Services
{
    public class ProductService
    {
        private static string db_source = "meghaserver3000.database.windows.net";
        private static string db_user = "sqladmin";
        private static string db_pass = "Tushar@19871980";
        private static string db_database = "meghadb";

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_pass;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);

        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();
            List<Product> productslist = new List<Product>();
            string statement = "select * from Products";
            conn.Open();
            SqlCommand cmd = new SqlCommand(statement, conn);
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product=new Product()
                    {
                        ProductID=reader.GetInt32(0),
                          ProductName=reader.GetString(1),
                           Quantity=reader.GetInt32(2)

                    };
                    productslist.Add(product);
                }
            }
            conn.Close();
            return productslist;


        }
    }
}
