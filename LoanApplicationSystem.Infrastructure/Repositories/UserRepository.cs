using LoanApplicationSystem.Application.Contracts;
using LoanApplicationSystem.Domain.Entities;

namespace LoanApplicationSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public User? GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
