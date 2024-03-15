namespace CsuNavigatorBackend.ApplicationServices.Services;

public interface IMapper<in TFrom, out TTo>
{
    TTo Map(TFrom from);
}