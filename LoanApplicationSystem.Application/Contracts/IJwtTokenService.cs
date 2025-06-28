using LoanApplicationSystem.Domain.Entities;

namespace LoanApplicationSystem.Application.Contracts
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
