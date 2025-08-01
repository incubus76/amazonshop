using System.Collections;
using Ecommerce.Application.Persistence;
using Ecommerce.Infrastructure.Persistence;

namespace Ecommerce.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private Hashtable? _repositories;
    private readonly EcommerceDbContext _context;

    public UnitOfWork(EcommerceDbContext context)
    {
        _context = context;
    }   

    public void Dispose()
    {
        _context.Dispose();
    }

    public IAsyncRepository<T> Repository<T>() where T : class
    {
        if (_repositories == null)
        {
            _repositories = new Hashtable();
        }

        var type = typeof(T).Name;
        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(RepositoryBase<>);
            var repositoryInstance = Activator.CreateInstance(typeof(RepositoryBase<T>), _context);
            _repositories.Add(type, repositoryInstance);
        }
        
        return (IAsyncRepository<T>)_repositories[type]!;
    }

    public async Task<int> Complete()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Handle exceptions as needed, e.g., log them
            throw new Exception("An error occurred while saving changes.", ex);
        }
    }
}