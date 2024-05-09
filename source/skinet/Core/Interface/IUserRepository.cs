using Core.Entities;

namespace Core.Interface
{
    public interface IUserRepository
    {
        public string constr { get; set; }

        Task<User> GetUserByIdAsync(int id);

        Task<IReadOnlyList<User>> GetUsersAsync();
    }
}