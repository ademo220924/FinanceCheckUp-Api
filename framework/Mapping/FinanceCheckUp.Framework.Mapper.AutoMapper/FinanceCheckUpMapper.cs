using AutoMapper;

namespace FinanceCheckUp.Framework.Mapper.AutoMapper;

public class FinanceCheckUpMapper(IMapperBase mapper) : IFinanceCheckUpMapper
{
    public TDestination Map<TSource, TDestination>(TSource source)
    {
        return mapper.Map<TSource, TDestination>(source);
    }
}