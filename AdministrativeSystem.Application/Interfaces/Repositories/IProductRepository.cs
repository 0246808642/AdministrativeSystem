using AdministrativeSystem.Domain.Entities;

namespace AdministrativeSystem.Application.Interfaces.Repositories;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id);
}