namespace LoanApplicationSystem.Api.Models.Requests
{
    public class RegisterRequest
    {
        public string Email { get; init; }
        public string Password { get; init; }

        public RegisterRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
