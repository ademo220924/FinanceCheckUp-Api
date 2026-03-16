using AutoMapper;
using FinanceCheckUp.Application.Features.BaseApp.Bultens.Command.Create;
using FinanceCheckUp.Application.Models.Requests;

namespace FinanceCheckUp.Application.Mapper;

public class BultenMapperProfile : Profile
{
    public BultenMapperProfile()
    {
        CreateMap<BultenCreateRequest, BultenCreateCommand>();
    }
}