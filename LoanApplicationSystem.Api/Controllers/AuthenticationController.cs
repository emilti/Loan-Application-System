

using ApiServer.Controllers;
using AutoMapper;
using LoanApplicationSystem.Application.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoanApplicationSystem.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : CustomControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public AuthenticationController(ISender mediator, IMapper mapper) : base(mediator, mapper) 
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            AuthenticationResult authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => (Problem(errors)));
        }
    }
}
