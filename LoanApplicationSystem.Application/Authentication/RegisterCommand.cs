using LoanApplicationSystem.Application.Common;
using MediatR;

namespace LoanApplicationSystem.Application.Authentication
{
    public class RegisterCommand : IRequest<Result<AuthenticationResult>>
    {
        public string Email { get; init; }
        public string Password { get; init; }

        public RegisterCommand( string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
