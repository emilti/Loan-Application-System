using LoanApplicationSystem.Domain.Entities;

namespace LoanApplicationSystem.Application.Contracts
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);

        void Add(User user);
    }
}
