using LoanApplicationSystem.Domain.Entities;

namespace LoanApplicationSystem.Application.Authentication
{
    public class AuthenticationResult
    {
        public User User { get; set; }

        public string Token {  get; set; }
    }
}
