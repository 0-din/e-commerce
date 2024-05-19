using System.Data.SqlClient;
using Core.Entities;
using Core.Interface;
using Core.Specifications;

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

        public async Task<User> GetByIdAsync(int id)
        {
            throw new Exception("Not found.");
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            throw new Exception("Not found.");
        }

        public Task<int> InsertAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        } 

        public Task DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetEntityWithSpec(ISpecification<User> spec)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<User>> ListAsync(ISpecification<User> spec)
        {
            throw new NotImplementedException();
        }
    }
}