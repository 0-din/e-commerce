using System.Data.SqlClient;
using Core.Entities;
using Core.Interface;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public string constr { get; set; }

        public UserRepository()
        {
            _connectionString = "";
        }

        public UserRepository(string connectionString = "Data source=skinet.db")
            : this()
        {
            constr = _connectionString = connectionString;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var com = new SqlCommand("select * from User where id = @id", conn))
            {
                conn.Open();
                com.Parameters.Add(new SqlParameter("@id", id));

                using (var reader = await com.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new User() 
                        { 
                            Id = (int)reader["Id"]
                            , UserName = (string)reader["UserName"] 
                            , FirstName = (string)reader["FirstName"] 
                            , LastName = (string)reader["LastName"] 
                            , Address = (string)reader["Address"] 
                            , Email = (string)reader["Email"]
                            , Mobile = (string)reader["Mobile"]
                        };
                    }
                }
            }

            throw new Exception("Not found.");
        }

        public async Task<IReadOnlyList<User>> GetUsersAsync()
        {
            var users = new List<User>();

            using (var conn = new SqlConnection(_connectionString))
            using (var com = new SqlCommand("select * from User", conn))
            {
                conn.Open();

                using (var reader = await com.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var user = new User() 
                        { 
                            Id = (int)reader["Id"]
                            , UserName = (string)reader["UserName"] 
                            , FirstName = (string)reader["FirstName"] 
                            , LastName = (string)reader["LastName"] 
                            , Address = (string)reader["Address"] 
                            , Email = (string)reader["Email"]
                            , Mobile = (string)reader["Mobile"]
                        };

                        users.Add(user);
                    }
                }
            }

            return users;
        }
    }
}