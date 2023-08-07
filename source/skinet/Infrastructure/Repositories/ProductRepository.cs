using System.Data.SqlClient;
using Core.Entities;
using Core.Interface;

namespace Core.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository()
        {
            _connectionString = "";
        }

        public ProductRepository(string connectionString)
            : this()
        {
            _connectionString = connectionString;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var com = new SqlCommand("select * from product where id = @id", conn))
            {
                conn.Open();
                com.Parameters.Add(new SqlParameter("@id", id));

                using (var reader = await com.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                        return new Product() { Id = (int)reader["Id"], Name = (string)reader["Name"] };
                }
            }

            throw new Exception("Not found.");
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
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