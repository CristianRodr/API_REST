namespace Usuarios.Domain.Abstractions;

//manejo del grabado en la base de datos

public interface IUnitOfWork 
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}