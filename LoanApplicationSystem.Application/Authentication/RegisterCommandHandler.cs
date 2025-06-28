using LoanApplicationSystem.Application.Common;
using LoanApplicationSystem.Application.Contracts;
using LoanApplicationSystem.Domain.Entities;

namespace LoanApplicationSystem.Application.Authentication
{
    internal class RegisterCommandHandler
    {
        private readonly IJwtTokenService _jwtTokenGenerator;

        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenService jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<Result<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Result.Failure<AuthenticationResult>("User Already exists");
            }

            var user = new User(command.Email);
            

            _userRepository.Add(user);

            var token = _jwtTokenGenerator.GenerateToken(user);
            AuthenticationResult result = new AuthenticationResult()
            {
                User = user,
                Token = token
            };

            return Result.Success<AuthenticationResult>(result);
        }
    }
}
