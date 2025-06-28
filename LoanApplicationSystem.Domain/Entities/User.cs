namespace LoanApplicationSystem.Domain.Entities
{
    public class User
    {
        public User(string email)
        {
            Email = email;
        }

        public string Email  { get; private set; }
    }
}
