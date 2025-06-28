namespace LoanApplicationSystem.Domain.Entities
{
    public class User
    {
        public string Email { get; private set; }
        public List<Role> Roles { get; private set; } = [];

        public User(string name, string email)
        {
            Email = email;
        }
    }
}
