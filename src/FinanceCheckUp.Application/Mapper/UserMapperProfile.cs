using AutoMapper;
using FinanceCheckUp.Application.Features.BaseApp.Users.Command.UserPasswordChange;
using FinanceCheckUp.Application.Models.Requests;

namespace FinanceCheckUp.Application.Mapper;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<UserPasswordChangeRequest, UserPasswordChangeCommand>();
    }
}