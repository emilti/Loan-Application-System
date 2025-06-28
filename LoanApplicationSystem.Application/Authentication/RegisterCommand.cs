using MediatR;

namespace LoanApplicationSystem.Application.Authentication
{
    public class RegisterCommand : IRequest<AuthenticationResult>
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
