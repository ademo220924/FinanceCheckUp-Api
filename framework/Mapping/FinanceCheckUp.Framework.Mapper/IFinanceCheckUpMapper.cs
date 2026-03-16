namespace FinanceCheckUp.Framework.Mapper;

public interface IFinanceCheckUpMapper
{
    TDestination Map<TSource, TDestination>(TSource source);
}