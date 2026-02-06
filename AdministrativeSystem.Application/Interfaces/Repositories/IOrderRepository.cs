using AdministrativeSystem.Domain.Entities;

namespace AdministrativeSystem.Application.Interfaces.Repositories;

public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task<Order?> GetByIdAsync(Guid id);
}