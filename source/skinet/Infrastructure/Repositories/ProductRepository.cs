using System.Data.SqlClient;
using Core.Entities;

namespace Core.Repositories
{
    public class ProductRepository
    {
        private readonly string _connectionString = "";

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = new List<Product>();

            using (var conn = new SqlConnection(_connectionString))
            using (var com = new SqlCommand("select * from product", conn))
            {
                conn.Open();

                using (var reader = await com.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        products.Add(new Product() { Id = (int)reader["Id"], Name = (string)reader["Name"] });
                    }
                }
            }

            return products;
        }
    }
}