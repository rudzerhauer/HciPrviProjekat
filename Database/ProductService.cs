using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WpfApp1.Models;

namespace WpfApp1.Database
{
    public class ProductService
    {
        private MySqlDbContext _dbContext;

        public ProductService()
        {
            _dbContext = new MySqlDbContext();
        }

        // Create - Add a new product
        public void CreateProduct(Product product)
        {
            using (var connection = _dbContext.GetConnection())
            {
                connection.Open();

                string query = "INSERT INTO product (Name, Price, Description, QuantityInStock) " +
                               "VALUES (@Name, @Price, @Description, @QuantityInStock)";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@QuantityInStock", product.QuantityInStock);

                cmd.ExecuteNonQuery();
            }
        }

        // Read - Get all products
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (var connection = _dbContext.GetConnection())
            {
                connection.Open();

                string query = "SELECT * FROM product";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductID = reader.GetInt32("ProductID"),
                            Name = reader.GetString("Name"),
                            Price = reader.GetDecimal("Price"),
                            Description = reader.GetString("Description"),
                            QuantityInStock = reader.GetInt32("QuantityInStock")
                        });
                    }
                }
            }

            return products;
        }

        // Read - Get product by ID
        public Product GetProductById(int productId)
        {
            Product product = null;

            using (var connection = _dbContext.GetConnection())
            {
                connection.Open();

                string query = "SELECT * FROM product WHERE ProductID = @ProductID";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductID", productId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        product = new Product
                        {
                            ProductID = reader.GetInt32("ProductID"),
                            Name = reader.GetString("Name"),
                            Price = reader.GetDecimal("Price"),
                            Description = reader.GetString("Description"),
                            QuantityInStock = reader.GetInt32("QuantityInStock")
                        };
                    }
                }
            }

            return product;
        }

        // Update - Update a product's information
        public void UpdateProduct(Product product)
        {
            using (var connection = _dbContext.GetConnection())
            {
                connection.Open();

                string query = "UPDATE product SET Name = @Name, Price = @Price, Description = @Description, " +
                               "QuantityInStock = @QuantityInStock WHERE ProductID = @ProductID";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@QuantityInStock", product.QuantityInStock);

                cmd.ExecuteNonQuery();
            }
        }

        // Delete - Remove a product
        public void DeleteProduct(int productId)
        {
            using (var connection = _dbContext.GetConnection())
            {
                connection.Open();

                string query = "DELETE FROM product WHERE ProductID = @ProductID";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductID", productId);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
