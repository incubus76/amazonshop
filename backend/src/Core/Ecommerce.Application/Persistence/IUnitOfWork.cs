namespace Ecommerce.Application.Persistence;

public interface IUnitOfWork:IDisposable
{
    IAsyncRepository<T> Repository<T>() where T : class;
    Task<int> Complete();
}