using AdministrativeSystem.Domain.Entities;
using AdministrativeSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AdministrativeSystem.Infrastructure.Repositories;

public class OrderRepository
{
    private readonly AppDbContext _dbContext;
    
    public OrderRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task AddAsync(Order order)
    {
        await _dbContext.Orders.AddAsync(order); 
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Orders.Include(o=>o.OrderItems)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task UpdateAsync(Order order)
    {
        _dbContext.Orders.Update(order);
        await _dbContext.SaveChangesAsync();
    }
}