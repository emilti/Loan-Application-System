using LoanApplicationSystem.Application.Authentication;
using Microsoft.AspNetCore.Identity.Data;
using AutoMapper;

namespace LoanApplicationSystem.Api.Configurations
{
    public class AuthenticationMappingProfile : Profile
    {
        public AuthenticationMappingProfile()
        {
            CreateMap<RegisterRequest, RegisterCommand>();
        }
    }
}
